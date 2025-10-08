import { useEffect, useState } from "react";
import CategoryButton from "../../../assets/Button/CategoryButton/CategoryButton";
import BlogCover from "../../BlogCover/BlogCover";
import './HomeContent.css';
import { GetBlogs } from "./HomeContentFunctions";
import type { BlogResponse } from "./HomeContentFunctions";
type CategoryButtonType = {
    buttonText: string,
    buttonImageUrl: string
}

export default function HomeContent() {
  const [data, setData] = useState<BlogResponse[]>([]);
  useEffect(() => {
    async function fetchBlogs() {
      const blogs = await GetBlogs();
      setData(blogs);
    }

    fetchBlogs();
  }, []);
    const CategoryButtonData: CategoryButtonType[] = [
        {
            buttonText: "News",
            buttonImageUrl: "./ButtonIcon/Images/newspaper.png"
        },
        {
            buttonText: "Idea",
            buttonImageUrl: "./ButtonIcon/Images/idea.png"
        }, {
            buttonText: "Finance",
            buttonImageUrl: "./ButtonIcon/Images/money.png"
        }, {
            buttonText: "Travel",
            buttonImageUrl: "./ButtonIcon/Images/plane.png"
        },
        {
            buttonText: "Sport",
            buttonImageUrl: "./ButtonIcon/Images/balls-sports.png"
        }, {
            buttonText: "Trending",
            buttonImageUrl: "./ButtonIcon/Images/trending-topic.png"
        },
    
    ]
    return (
        <div className="container">
            <div className="content">
                <div className="subtitle">
                    Explore Trending Topics
                </div>
                <div className="catogory-button-container">
                    <div className="categories-button">
                        {CategoryButtonData.map ((buttonData) => (
                            <CategoryButton buttonText={buttonData.buttonText} 
                            imageUrl={buttonData.buttonImageUrl} 
                            key= {buttonData.buttonText} />
                        ))}                     
                    </div>
                </div>
                <div className="blog-list-container">
                    <div className="blog-list">
                        {data.map ((blog : BlogResponse) => (
                            <BlogCover blogId={blog.id} description={blog.description} title={blog.title} imageUrl="./ButtonIcon/Images/financeblogimagedummy.jpg"/>
                        ))}
                    </div>
                </div>
            </div>
        </div>
    )
}