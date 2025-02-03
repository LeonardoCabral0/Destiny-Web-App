import React from 'react'
import styles from './styles.module.css'
import { motion } from 'framer-motion';

export const Modal = ({children, close}) => {
  return (
    <div className={styles.wrapper}>
        <motion.div 
        initial={{ opacity: 0, scale: 0.8, y: -100 }}
        animate={{
          opacity: 1,
          scale: 1,
          rotate: 0,
        }}
        exit={{
          opacity: 0,
          scale: 0.8,
          rotate: 10,
          y: 100,
        }}
        transition={{
          duration: 0.3,
          ease: 'easeInOut',
        }}
        className={styles.modal}>
            <span onClick={close} className={styles.iconClose}>X</span>
            {children}
        </motion.div>
    </div>
  )
}
