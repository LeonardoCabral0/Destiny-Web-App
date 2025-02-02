import React, { useState } from 'react'
import styles from './styles.module.css'
import { Modal } from '../Modal/Modal'

export const Card = ({ touristSpot }) => {
  const [modalIsOpen, setModalIsOpen] = useState(false)

  function openModal() {
    setModalIsOpen(true)
  }

  function closeModal() {
    setModalIsOpen(false)
  }

  return (
    <>
      <div className={styles.wrapper} onClick={openModal}>
        <p className={styles.title}>{touristSpot.name}</p>
        <p className={styles.subTitle}>{touristSpot.localization}, {touristSpot.city} - {touristSpot.state}</p>
      </div>

      {modalIsOpen && (
        <Modal close={closeModal}>
          <p className={styles.modalContent}><span className={styles.title}>Nome:</span> {touristSpot.name}</p>
          <p className={styles.modalContent}><span className={styles.title}>Endereço/Referência:</span> {touristSpot.localization}</p>
          <p className={styles.modalContent}><span className={styles.title}>Cidade:</span> {touristSpot.city}</p>
          <p className={styles.modalContent}><span className={styles.title}>Estado:</span> {touristSpot.state} </p>
          <p className={styles.modalContent}><span className={styles.title}>Descrição:</span> {touristSpot.description}</p>
        </Modal>)}
    </>
  )
}
