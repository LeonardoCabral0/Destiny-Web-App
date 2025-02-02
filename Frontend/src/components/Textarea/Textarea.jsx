import React from 'react'
import styles from './styles.module.css'

export const Textarea = ({ name, label, value, onChange, onBlur, error }) => {
    return (
        <div className={styles.wrapper}>
            <label className={styles.label} htmlFor={name}>{label}</label>
            <textarea id={name} name={name} value={value} onChange={onChange} onBlur={onBlur} className={styles.input}>
            </textarea>
            {error && <p className={styles.error}>{error} </p>}
        </div>
    )
}
