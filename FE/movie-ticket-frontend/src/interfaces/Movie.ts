export interface Movie {
    id: number;
    title: string;
    imageUrl: string;
  }
  
  export interface MovieDetails extends Movie {
    genre: string;
    description: string;
    duration: string;
    releaseDate: string;
    director: string;
    language: string;
    actors: string[];
    rated: string;
  }
  