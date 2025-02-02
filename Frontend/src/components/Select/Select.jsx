import React from 'react'
import styles from './styles.module.css'

export const Select = ({ valuesList, name, label, value, error, onChange, disabled }) => {
    return (
        <div className={styles.wrapper}>
            <label className={styles.label} htmlFor={name}>{label}</label>
            <select disabled={disabled} id={name} name={name} value={value} onChange={onChange} className={`${styles.input} ${error ? styles.error : undefined}`}>
                <option value=""></option>
                {valuesList.map((state) => (
                    <option key={state.sigla} value={state.sigla} >
                        {state.nome}
                    </option>
                ))}
            </select>
        </div>

    )
}
