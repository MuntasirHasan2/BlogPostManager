import './BlogCover.css';

type BlogCoverProps = {
    blogId : number,
    title: string,
    description : string,
    imageUrl : string,
}

export default function BlogCover({blogId,title, description, imageUrl} : BlogCoverProps) {
    return (
        <>
            <div className="box">
                <div
                id={blogId.toString()} 
                className="blog-frame">
                    <div className="blog-image-hightlight">
                        <img src={imageUrl}/>
                    </div>
                    <div className="blog-title">
                        {title}
                    </div>
                    <div className="blog-short-description">
                        {description}
                    </div>
                </div>
            </div>
        </>
    )
}