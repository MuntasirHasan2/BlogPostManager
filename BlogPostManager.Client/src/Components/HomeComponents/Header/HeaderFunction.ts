export function ScrollBy100VH() {
    console.log("Clicked");
    const scrollableDiv : HTMLElement | null | undefined= document.getElementById('HomeHeader');
    if(scrollableDiv == null)
        return;
    window.scrollBy({
        top: scrollableDiv.clientHeight, 
        behavior: 'smooth'
    });

}