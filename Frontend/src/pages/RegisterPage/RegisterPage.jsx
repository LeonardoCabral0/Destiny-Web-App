import React, { useState } from 'react'
import styles from './styles.module.css'
import { Input } from '../../components/Input/Input';
import { Select } from '../../components/Select/Select';
import { Textarea } from '../../components/Textarea/Textarea';
import { ButtonForm } from '../../components/ButtonForm/ButtonForm';
import { useForm } from '../../hooks/UseForm';
import api from '../../utils/api';
import { statesBrazil } from '../../utils/constants';

export const RegisterPage = () => {
  const name = useForm();
  const city = useForm();
  const state = useForm();
  const localization = useForm();
  const descpription = useForm('description');

  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = async event => {
    event.preventDefault()

    const allValuesIsValid = name.validate() && city.validate() && state.validate() && localization.validate() && descpription.validate()

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
      } catch (e) {
        setError("Ocorreu um erro inesperado, tente novamento mais tarde!")
      }finally{
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

  return (
    <section className={styles.wrapper}>
      <form className={styles.form}>
        <h2>Cadastre um novo ponto turístico!</h2>
        <Input label="Nome:" name="name" {...name} />
        <section className={styles.containerAdress}>
          <Input label="Cidade:" name="city" {...city} />
          <Select label="UF:" name="state" valuesList={statesBrazil} {...state} />
        </section>
        <Input label="Referência/Endereço:" name="localization" {...localization} />
        <Textarea label="Descrição:" name="description" {...descpription} />
        <ButtonForm disabled={isLoading} onClick={handleSubmit}>Cadastre</ButtonForm>
        {error && <p className={styles.error}>{error}</p>}
      </form>
    </section>
  )
}
