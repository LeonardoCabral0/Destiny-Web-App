import React from 'react'
import styles from './styles.module.css'

export const Input = ({ props }) => {
  return (
    <input {...props} className={styles.input}/>
  )
}
