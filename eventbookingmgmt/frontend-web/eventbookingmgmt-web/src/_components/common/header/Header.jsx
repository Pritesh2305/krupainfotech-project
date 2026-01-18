import React from 'react'
import { NavLink } from 'react-router'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAlignLeft } from '@fortawesome/free-solid-svg-icons'
import { PiUserGearFill } from "react-icons/pi";

export default function Header() {
    const handlesidebar = () => {
        console.log("click");
        var el = document.getElementById("wrapper");
        var toggleButton = document.getElementById("menu-toggle");
        toggleButton.onclick = function () {
            el.classList.toggle("toggled");
        };
    }
    return (
        <>
        <header>
            <nav className="navbar navbar-expand-lg navbar-light bg-transparent py-2 px-4">
                <div className="d-flex align-items-center">
                    <FontAwesomeIcon icon={faAlignLeft} className="primary-text fs-4 me-2" id="menu-toggle" onClick={handlesidebar} />
                    <h2 className="fs-6 m-0">EVENT MANAGEMENT</h2>
                </div>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
                        <li className="nav-item dropdown">
                            <a className="nav-link dropdown-toggle second-text fw-bold" href="#" id="navbarDropdown"
                                role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                <PiUserGearFill size={25} />
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="navbarDropdown">
                                {/* <li><a className="dropdown-item" href="#">Profile</a></li>
                                <li><a className="dropdown-item" href="#">Settings</a></li> */}
                                {/* <li><a className="dropdown-item" href="#">Logout</a></li> */}
                                <li> <NavLink className='dropdown-item link' to="/auth/login">Logout</NavLink></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </nav>
            </header>
        </>

    )
}
