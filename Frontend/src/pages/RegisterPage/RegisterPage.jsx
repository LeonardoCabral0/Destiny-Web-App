import React, { useState } from 'react'
import styles from './styles.module.css'
import { Input } from '../../components/Input/Input';
import { Select } from '../../components/Select/Select';
import { Textarea } from '../../components/Textarea/Textarea';
import { ButtonForm } from '../../components/ButtonForm/ButtonForm';
import { useForm } from '../../hooks/UseForm';

export const RegisterPage = () => {
  const name = useForm();
  const city = useForm();
  const state = useForm();
  const localization = useForm();
  const descpription = useForm();

  return (
    <section className={styles.wrapper}>
      <form className={styles.form}>
        <h2>Cadastre um novo ponto turístico!</h2>
        <Input label="Nome:" name="name" {...name} />
        <section className={styles.containerAdress}>
          <Input label="Cidade:" name="city" {...city} />
          <Select label="UF:" name="state" {...state} />
        </section>
        <Input label="Referência/Endereço:" name="localization" {...localization} />
        <Textarea label="Descrição:" name="description" {...descpription} />
        <ButtonForm>Cadastre</ButtonForm>
      </form>
    </section>
  )
}
