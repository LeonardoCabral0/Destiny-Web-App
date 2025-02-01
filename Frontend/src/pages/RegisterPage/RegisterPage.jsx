import React, { useState } from 'react'
import styles from './styles.module.css'

export const RegisterPage = () => {
    const [selectedState, setSelectedState] = useState("");

    return (
      <section className={styles.wrapper}>
        <form className={styles.form}>
          <h2>Cadastre um novo ponto turístico!</h2>
          <section className={styles.containerInputName}>
            <label htmlFor='name'>Name:</label>
            <input className={styles.inputName} id="name" type="text" placeholder='Digite o nome do ponto turístico' />
          </section>
          <section className={styles.containerLocalization}>
            <label htmlFor='cidade'>Localizacação:</label>
            <section>
              <label htmlFor='cidade'>UF/Cidade:</label>
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
                <input className={styles.inputCity} id="cidade" type="text" />
              </section>
  
            </section>
            <label htmlFor='cidade'>Localizacação:</label>
            <input className={styles.inputReferency} id="referencia" type="text" />
          </section>
          <section className={styles.containerDescription}>
            <label htmlFor='descricao'>Referência:</label>
            <textarea id="descricao"/>
          </section>
          <button className={styles.buttonForm}>Cadastre</button>
        </form>
      </section>
    )
}
