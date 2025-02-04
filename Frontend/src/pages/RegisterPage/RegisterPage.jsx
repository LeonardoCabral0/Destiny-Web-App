import React, { useEffect, useState } from 'react'
import styles from './styles.module.css'
import { Input } from '../../components/Input/Input';
import { Select } from '../../components/Select/Select';
import { Textarea } from '../../components/Textarea/Textarea';
import { ButtonForm } from '../../components/ButtonForm/ButtonForm';
import { useForm } from '../../hooks/UseForm';
import api from '../../utils/api';
import { statesBrazil } from '../../utils/constants';
import { Modal } from "../../components/Modal/Modal"
import { FaCheckCircle } from 'react-icons/fa';
import axios from 'axios';

export const RegisterPage = () => {
  const name = useForm();
  const city = useForm();
  const state = useForm();
  const localization = useForm();
  const descpription = useForm('description');

  const [modalIsOnpen, setModalIsOpen] = useState(false)

  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const [currentCitys, setCurrentCitys] = useState([])

  useEffect(() => {
    const fetchCitys = async () => {
      if (state.value) {
        const response = await axios.get(`https://servicodados.ibge.gov.br/api/v1/localidades/estados/${state.value}/municipios`)
        setCurrentCitys(response.data)
        return
      }
      setCurrentCitys([])
      city.setValue('')
    }

    fetchCitys()
  }, [state.value])

  const handleSubmit = async event => {
    event.preventDefault()
    const allValuesIsValid = name.validate() && state.validate() && city.validate() && localization.validate() && descpription.validate() 
    if (allValuesIsValid) {
      const requestBody = {
        name: name.value,
        description: descpription.value,
        localization: localization.value,
        city: city.value,
        state: state.value
      }
      try {
        setIsLoading(true)
        const reponse = await api.post("/TouristSpot", requestBody)
        clearInputs()
        setError(null)
        setModalIsOpen(true)
      } catch (e) {
        setError("Ocorreu um erro inesperado, tente novamento mais tarde!")
      } finally {
        setIsLoading(false)
      }
    }
  }

  function clearInputs() {
    name.setValue('')
    city.setValue('')
    state.setValue('')
    localization.setValue('')
    descpription.setValue('')
  }

  function closeModal() {
    setModalIsOpen(false)
  }

  return (
    <>
      <section className={styles.wrapper}>
        <form className={styles.form}>
          <h2>Cadastre um novo ponto turístico!</h2>
          <Input label="Nome:" name="name" {...name} />
          <section className={styles.containerAdress}>
            <Select disabled={state.value === ""} label="Cidade:" name="city" valuesList={currentCitys} {...city}>
              {currentCitys.map((city) => (
                <option key={city.id} value={city.nome} >
                  {city.nome}
                </option>
              ))}
            </Select>
            <Select label="UF:" name="state" valuesList={statesBrazil} {...state}>
              {statesBrazil.map((state) => (
                <option key={state.sigla} value={state.sigla} >
                  {state.nome}
                </option>
              ))}
            </Select>
          </section>
          <Input label="Referência/Endereço:" name="localization" {...localization} />
          <Textarea label="Descrição:" name="description" {...descpription} />
          <ButtonForm disabled={isLoading} onClick={handleSubmit}>Cadastre</ButtonForm>
          {error && <p className={styles.error}>{error}</p>}
        </form>
      </section>
      {modalIsOnpen && (
        <Modal close={closeModal}>
          <div className={styles.containerSucessModal}>
            <FaCheckCircle size={68} className={styles.iconCheck} />
            <p className={styles.textSucessModal}>Cadastrado com sucesso!</p>
          </div>
        </Modal>)}
    </>

  )
}
