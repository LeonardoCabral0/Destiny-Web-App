import React from 'react'
import styles from './styles.module.css'
import { Card } from '../../../components/Card/Card'

export const CardContainer = ({touristsSpots}) => {
    return (
        <div>
            {touristsSpots.length === 0 ? <p>Nenhum resultado encontrado</p>: touristsSpots.map(touristSpot => <Card touristSpot={touristSpot} />)}
        </div>
    )
}
