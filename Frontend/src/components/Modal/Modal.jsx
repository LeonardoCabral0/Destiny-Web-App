import React from 'react'
import styles from './styles.module.css'

export const Modal = ({children, close}) => {
  return (
    <div className={styles.wrapper}>
        <div className={styles.modal}>
            <span onClick={close} className={styles.iconClose}>X</span>
            {children}
        </div>
    </div>
  )
}
