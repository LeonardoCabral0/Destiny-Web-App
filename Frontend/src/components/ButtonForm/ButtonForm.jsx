import React from 'react'
import styles from './styles.module.css'

export const ButtonForm = ({children, onClick, disabled }) => {
  return (
    <button disabled={disabled} className={styles.button} onClick={onClick}>{children}</button>
  )
}
