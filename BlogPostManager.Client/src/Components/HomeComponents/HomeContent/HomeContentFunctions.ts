export type BlogResponse =  {
  id: number,
  title: string,
  description: string,
  categoryId: number,
  content: string,
  mainImage: Uint8Array | null,
  images: Uint8Array[] | null,
  lastModifiedDate: string,
  userId: string,
}


export async function GetBlogs(): Promise<BlogResponse[]> {
  try {
    const response = await fetch('http://localhost:5154/blog/list');
    if (!response.ok) {
      console.log("Error");
    }

    const data: BlogResponse[] = await response.json();
    data.forEach((d) => console.log(d));

    return data;
  } catch (error) {
    console.error('Error :', error);
    return [];
  }
}
