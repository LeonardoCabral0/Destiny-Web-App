import React from 'react'
import styles from './styles.module.css'

export const ButtonForm = ({children, props}) => {
  return (
    <button className={styles.button} {...props}>{children}</button>
  )
}
