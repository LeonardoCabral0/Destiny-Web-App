import React from 'react'
import { statesBrazil } from '../../utils/constants';
import styles from './styles.module.css'

export const Select = ({ name, label, value, onChange }) => {
    return (
        <div className={styles.wrapper}>
            <label className={styles.label} htmlFor={name}>{label}</label>
            <select id={name} name={name} value={value} onChange={onChange} className={styles.input}>
                <option value=""></option>
                {statesBrazil.map((state) => (
                    <option key={state.sigla} value={state.sigla} >
                        {state.nome}
                    </option>
                ))}
            </select>
        </div>

    )
}
