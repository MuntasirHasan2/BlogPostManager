import './CategoryButton.css';
type btnProps = {
    buttonText : string,
    imageUrl : string
}

export default function CategoryButton({buttonText, imageUrl} : btnProps) {
    return (
        <>
            <div className="button-shell">
                <div className="button-inner-shell">
                    <div className="button-image">
                        <img src={imageUrl} alt='icon'/>
                    </div>
                    <div className="button-text">
                        {buttonText}
                    </div>
                </div>
            </div>
        </>
    )
}