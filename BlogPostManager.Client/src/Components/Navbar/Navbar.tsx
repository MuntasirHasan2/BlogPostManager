import BPMLogov2 from '../../assets/Navbar/BPMLogov2.png';
import './Navbar.css';
import { Link, useLocation } from "react-router";
//import { Signout } from './NavbarFunctions';

export default function Navbar() {
    const location = useLocation();
    
    return (
        <>
            <div className='nav'>
                <div className="logo">
                    <img src={BPMLogov2} alt='Blog Post Manager Logo' />
                </div>
                <div className="navlinks">
                    <div className="home">
                        <Link className={location.pathname == "/" ? "active-link" : ""}
                            to="/">
                            Home
                        </Link>
                    </div>
                    <div className="explore">
                        Explore
                    </div>
                    <div className="about">
                        About
                    </div>
                </div>
            </div>
        </>
    )
}