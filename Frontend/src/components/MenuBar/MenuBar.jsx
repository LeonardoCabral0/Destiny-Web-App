import React, { useEffect, useRef, useState } from 'react'
import styles from './styles.module.css'
import { gsap } from 'gsap'
import { useGSAP } from '@gsap/react'
import { Link } from 'react-router-dom';

const menuLinks = [
  { path: "/", label: "Home" },
  { path: "/cadastro", label: "Cadastrar" },
  { path: "/explorar", label: "Explorar" },
];

export const MenuBar = () => {
  const container = useRef()
  const containerContet = useRef()
  const links = useRef([])
  const tl = useRef()

  const [isMenuOpen, setIsMenuOpen] = useState(false)

  const toggleMenu = () => {
    setIsMenuOpen(prev => !prev)
  }

  useGSAP(() => {
    gsap.set(links.current, { y: 75 });

    tl.current = gsap.timeline({ paused: true }).to(containerContet.current, {
      duration: 1.25,
      clipPath: "polygon(0 0, 100% 0, 100% 100%, 0 100%)",
      ease: "power4.inOut"
    }).to(links.current, {
      y: 0,
      duration: 1,
      stagger: 0.1,
      ease: "power4.out",
      delay: -0.75,
    });
  }, { scope: container })

  useEffect(() => {
    if (isMenuOpen) {
      tl.current.play()
    } else {
      tl.current.reverse()
    }
  }, [isMenuOpen])

  return (
    <header className={styles.wrapper} ref={container}>
      <div className={styles.menuBar}>
        <h1 className={styles.logo}>
          DESTINY
        </h1>
        <div className={styles.menuLogo}>
          <button className={styles.menuButtonOpen} onClick={toggleMenu}>
            Menu
          </button>
        </div>
      </div>
      <div className={styles.containerMenuContent} ref={containerContet}>
        <div className={styles.menuBarCopy}>
          <h1 className={styles.logo}>
            DESTINY
          </h1>
          <div className={styles.menuLogo}>
            <button className={styles.menuButtonClose} onClick={toggleMenu}>
              Close
            </button>
          </div>
        </div>
        <section className={styles.menuContent}>
          <ul className={styles.containerList}>
            {menuLinks.map((item, index) => {
              return (
                <li key={index} className={styles.itemList} >
                  <div ref={(el) => (links.current[index] = el)}>
                    <Link onClick={toggleMenu} to={item.path}>{item.label}</Link>
                  </div>
                </li>)
            })}
          </ul>
        </section>
      </div>
    </header>
  )
}
