import React, { useState } from 'react'

export const useForm = () => {
    const [value, setValue] = useState('')

    const onChange = ({ target }) => {
        setValue(target.value)
    }

    return {
        value,
        setValue,
        onChange
    }
}
