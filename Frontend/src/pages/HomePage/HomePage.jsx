import React, { useRef } from 'react'
import styles from './styles.module.css'
import { Link } from 'react-router-dom'
import { slideUp, opacity } from './animation';
import { useInView, motion } from 'framer-motion';

export const HomePage = () => {
  const phrase = "Este site é uma plataforma experimental onde você pode explorar pontos turísticos de diferentes lugares. Veja como as informações sobre cada destino podem ser apresentadas de maneira simples e interativa."
  return (
    <div className={styles.wrapper}>
      <div>
        <h2 className={styles.title}>Explore os Melhores Pontos Turísticos</h2>
        <p className={styles.subTitle}>
          {
            phrase.split(" ").map((word, index) => {
              return <span key={index} className={styles.mask}><motion.span variants={slideUp} custom={index} animate="open" initial="initial" key={index}>{word}</motion.span></span>
            })
          }
        </p>
        <div className={styles.containerButtons}>
          <Link className={`${styles.button} ${styles.ligth}`} to="/cadastro">Cadastrar</Link>
          <Link className={`${styles.button} ${styles.dark}`} to="/explorar">Explorar</Link>
        </div>
      </div>
    </div>
  )
}
