import React from 'react'
import styles from './styles.module.css'

export const Label = ({ children, props}) => {
  return (
    <label className={styles.label} {...props}>{children}</label>
  )
}
