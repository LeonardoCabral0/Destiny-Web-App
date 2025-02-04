import React, { useEffect, useRef, useState } from 'react'
import styles from './styles.module.css'
import { FaAngleLeft, FaAngleRight, FaSearch } from "react-icons/fa";
import { Card } from '../../components/Card/Card';
import api from '../../utils/api';
import { Loading } from './Loading/Loading';
import { CardContainer } from './CardContainer/CardContainer';

const MAX_PAGE_SIZE = 10

export const ExplorerPage = () => {
  const [touristsSpots, setTouristsSpots] = useState([])
  const [currentPage, setCurrentPage] = useState(1)
  const [currentOrderby, setCurrentOrderby] = useState("DESC")
  const [currentSearchWord, setCurrentSearchWord] = useState("")
  const [isLoading, setIsLoading] = useState(false)

  const getAllTouristsSpots = async () => {
    setIsLoading(true)
    try {
      const response = await api.get(`touristspot?searchWord=${currentSearchWord}&orderBy=${currentOrderby}&page=${currentPage}&pageSize=${MAX_PAGE_SIZE}`)
      console.log(response.data)
      if (response.data) setTouristsSpots(response.data.touristsSpots)
      else setTouristsSpots([])
    } catch (e) {
      setTouristsSpots([])
    } finally {
      setIsLoading(false)
    }
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
              <option value="DESC">Decrescente</option>
              <option value="ASC">Crescente</option>
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
          {isLoading ? <Loading /> : <CardContainer touristsSpots={touristsSpots} />}
        </div>
      </div>
    </section>
  )
}
