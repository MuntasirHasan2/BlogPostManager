import './Header.css';
import HomeArray from '../../../assets/Home/HomeArray';
import { ScrollBy100VH } from './HeaderFunction';
export default function Header() {
    return (

        <div className="container" id='HomeHeader'>
            <div className="header-content">
                <h2 className="title">
                    <div className="title-heading">

                        Explore <span className='keywork'> Ideas </span> ,
                        Find <span className='keywork'> Inspirations </span> ,
                        and Inspire Your <span className='keywork'> Creativity </span>
                    </div>
                    <div className="title-subheading">
                        Read blogs from our creator who spark ideas, stories that move you, and insights that stay
                        with you — through blogs that celebrate creativity, storytelling, and the power of shared ideas
                    </div>
                </h2>
                <span onClick={ScrollBy100VH}>
                    <HomeArray />
                </span>
            </div>
        </div>

    )
}