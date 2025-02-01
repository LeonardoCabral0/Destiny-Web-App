import React, { useState } from 'react'
import styles from './styles.module.css'
import { statesBrazil } from '../../utils/constants';
import { Input } from '../../components/Input/Input';
import { Label } from '../../components/Label/Label';

export const RegisterPage = () => {
    const [selectedState, setSelectedState] = useState("");

    return (
      <section className={styles.wrapper}>
        <form className={styles.form}>
          <h2>Cadastre um novo ponto turístico!</h2>
          <section className={styles.containerInputName}>
            <Label htmlFor='name'>Name:</Label>
            <Input id="name" type="text" placeholder='Digite o nome do ponto turístico' />
          </section>
          <section className={styles.containerLocalization}>
            <Label htmlFor='cidade'>Localizacação:</Label>
            <section>
              <Label htmlFor='cidade'>UF/Cidade:</Label>
              <section className={styles.containerAdress}>
                <select
                  id="estados"
                  value={selectedState}
                  onChange={(e) => setSelectedState(e.target.value)}
                  className={styles.containerStates}
                >
                  <option value=""></option>
                  {statesBrazil.map((state) => (
                    <option key={state.sigla} value={state.sigla}>
                      {state.nome}
                    </option>
                  ))}
                </select>
                <Input id="cidade" type="text" />
              </section>
  
            </section>
            <Label htmlFor='cidade'>Localizacação:</Label>
            <Input id="referencia" type="text" />
          </section>
          <section className={styles.containerDescription}>
            <Label htmlFor='descricao'>Referência:</Label>
            <textarea id="descricao"/>
          </section>
          <button className={styles.buttonForm}>Cadastre</button>
        </form>
      </section>
    )
}
