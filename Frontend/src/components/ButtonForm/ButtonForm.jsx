import React from 'react'
import styles from './styles.module.css'

export const ButtonForm = ({children, onClick}) => {
  return (
    <button className={styles.button} onClick={onClick}>{children}</button>
  )
}
