import React, { useState } from 'react'

const types = {
    description:{
        regex:/^.{101,}$/,
        message:"A descrição não pode ser maior que 100 caracteres!"
    }
}

export const useForm = (type) => {
    const [value, setValue] = useState('')
    const [error, setError] = useState(null)

    const onChange = ({ target }) => {
        if(error) validate(target.value)
        setValue(target.value)
    }

    const validate = value => {
        if(type === false) return true;

        if (value.length === 0) {
            setError("O campo não pode ser vazio!")
            return false
        }
        
        if(isValidType(type) && types[type].regex.test(value))
        {
            setError(types[type].message)
            return false
        }

        setError(null)
        return true
    }

    return {
        value,
        setValue,
        onChange,
        error,
        validate: () => validate(value),
        onBlur: () => validate(value)
    }
}


function isValidType(type){
    return types[type]
}