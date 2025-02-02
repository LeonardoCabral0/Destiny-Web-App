import React from 'react'
import styles from './styles.module.css'

export const Card = ({ touristSpot }) => {
  return (
    <div className={styles.cardContainer}>
      {touristSpot.name}
    </div>
  )
}
