import React, { useEffect, useRef, useState } from 'react'
import styles from './styles.module.css'
import { FaAngleLeft, FaAngleRight, FaSearch } from "react-icons/fa";
import { useGSAP } from '@gsap/react';
import gsap from 'gsap';
import { Card } from '../../components/Card/Card';
import api from '../../utils/api';
import { Modal } from '../../components/Modal/Modal';

export const ExplorerPage = () => {
  const [touristsSpots, setTouristsSpots] = useState([])
  const [currentPage, setCurrentPage] = useState(1)
  const [currentOrderby, setCurrentOrderby] = useState("ASC")
  const [currentSearchWord, setCurrentSearchWord] = useState("")

  const getAllTouristsSpots = async () => {
    const response = await api.get(`TouristSpot/?searchWord=${currentSearchWord}&orderBy=${currentOrderby}&page=${currentPage}`)
    if (response.data) setTouristsSpots(response.data.touristsSpots)
    else setTouristsSpots([])
  }

  useEffect(() => {
    getAllTouristsSpots()
  }, [])

  useEffect(() => {
    getAllTouristsSpots()
  }, [currentPage, currentOrderby])

  const incrementPage = () => {
    setCurrentPage(prev => prev + 1)
  }

  const decrementPage = () => {
    if (currentPage > 1) setCurrentPage(prev => prev - 1)
  }

  const handleSearchClick = async () => {
    await getAllTouristsSpots()
  }

  return (
    <section className={styles.wrapper}>
      <div className={styles.container}>
        <div className={styles.containerSearch}>
          <div className={styles.containerMenuSearch}>
            <input className={styles.searchInput} onChange={({ target }) => setCurrentSearchWord(target.value)} value={currentSearchWord} type="text" />
            <button className={styles.searchButton} onClick={handleSearchClick}>
              <FaSearch className={styles.searchIcon} size={16} />
            </button>
          </div>
          <div className={styles.containerOptions}>
            <select onChange={({ target }) => setCurrentOrderby(target.value)} className={styles.orderOptions}>
              <option value="ASC">Crescente</option>
              <option value="DESC">Decrescente</option>
            </select>
            <div className={styles.paginationContainer}>
              <button className={styles.paginationButton} onClick={decrementPage}>
                <FaAngleLeft size={16} className={styles.iconPaginationButton} />
              </button>
              <div className={styles.paginationDisplay}>
                <p>{currentPage}</p>
              </div>
              <button className={styles.paginationButton} onClick={incrementPage}>
                <FaAngleRight size={16} className={styles.iconPaginationButton} />
              </button>
            </div>
          </div>
        </div>
        <div className={styles.containerContent}>
          {touristsSpots.map(touristSpot => <Card touristSpot={touristSpot} />)}
        </div>
      </div>
    </section>
  )
}
