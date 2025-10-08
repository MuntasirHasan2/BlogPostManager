import { useParams } from "react-router-dom";

export default function Post() {
    const { postId } = useParams();
    console.log(postId);
    return (
        <>
        <h2>Route ID:  {postId}</h2>
        </>
    )
}