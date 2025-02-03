import React, { useRef } from 'react'
import styles from './styles.module.css'
import { useGSAP } from '@gsap/react';
import gsap from 'gsap';

export const Loading = () => {
    const ballRefs = useRef([])
    const tl = useRef()

    useGSAP(() => {
        tl.current = gsap.timeline({ repeat: -1, yoyo: true })
            .fromTo(ballRefs.current, { y: -10, duration: 0.5, ease: 'power1.inOut',  }, { y: 10, duration: 0.5, ease: 'power1.inOut', stagger: 0.2})
    }, []);

    return (
        <div className={styles.wrapper}>
            <div className={styles.containerBalls}>
                {[0, 1, 2].map((index) => (
                    <div
                        key={index}
                        ref={(el) => (ballRefs.current[index] = el)}
                        className={styles.ball}
                    ></div>
                ))}
            </div>
        </div>
    )
}
