import React, { useEffect, useRef, useState } from 'react'
import styles from './styles.module.css'
import { FaSearch } from "react-icons/fa";
import { useGSAP } from '@gsap/react';
import gsap from 'gsap';
import { Card } from '../../components/Card/Card';
import api from '../../utils/api';

export const ExplorerPage = () => {
  const [touristsSpots, setTouristsSpots] = useState([])

  const searchBar = useRef()
  const tl = useRef()

  useGSAP(() => {
    gsap.set(searchBar.current, { borderRadius: "0%" });
    tl.current = gsap.timeline().fromTo(searchBar.current, 
      { scaleX: 0, transformOrigin: 'center' }, 
      { scaleX: 1, duration: 1, ease: "power4.inOut", transformOrigin: 'center', delay: 0.4})
      .to(searchBar.current, {
        borderRadius: "2rem"
      }, "-=0.3")

  }, {})

  useEffect(()=>{
    const getAllTouristsSpots = async () => {
      const response = await api.get("TouristSpot")
      setTouristsSpots(response.data.touristsSpots)
    }

    getAllTouristsSpots()
  }, [])
  return (
    <section className={styles.wrapper}>
      <div className={styles.container}>
        <div className={styles.containerSearch}>
          <div className={styles.containerMenuSearch}>
            <input ref={searchBar} className={styles.searchInput} type="text" />
            <button className={styles.searchButton}>
              <FaSearch className={styles.searchIcon} size={16} />
            </button>
          </div>
        </div>
        <div className={styles.containerContent}>
          {touristsSpots.map(touristSpot => <Card touristSpot={touristSpot}/>)}
        </div>
      </div>
    </section>
  )
}
