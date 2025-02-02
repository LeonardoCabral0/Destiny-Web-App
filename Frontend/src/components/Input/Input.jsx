import React from 'react'
import styles from './styles.module.css'

export const Input = ({ label, name, value, onChange }) => {
  return (
    <div className={styles.wrapper}>
      <label className={styles.label} htmlFor={name}>{label}</label>
      <input id={name} name={name} value={value} onChange={onChange} className={styles.input} />
    </div>
  )
}
