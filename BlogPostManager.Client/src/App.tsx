import Home from './Pages/Home';
import Blog from './Pages/Blog';
import Navbar from './Components/Navbar/Navbar';
import Post from './Pages/Post';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css'

function App() {
  return (
    <>
      <BrowserRouter>
      <Navbar />
        <Routes>
          {/* <Route path="/" element={<Layout />}> */}
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<Blog />} />
          <Route path="/Blog/:postId" element={<Post />} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
