// src/components/MovieCarousel.tsx

import React from 'react';
import { Carousel } from 'react-responsive-carousel';
import 'react-responsive-carousel/lib/styles/carousel.min.css';

interface Movie {
  id: number;
  title: string;
  genre: string;
  releaseDate: string;
  imageUrl: string;
}

interface MovieCarouselProps {
  movies: Movie[];
}

const MovieCarousel: React.FC<MovieCarouselProps> = ({ movies }) => {
  return (
    <Carousel showThumbs={false} infiniteLoop useKeyboardArrows autoPlay>
      {movies.map(movie => (
        <div key={movie.id}>
          <img src={movie.imageUrl.startsWith('http') ? movie.imageUrl : `https://localhost:5001${movie.imageUrl}`} alt={movie.title} />
          <p className="legend">{movie.title}</p>
        </div>
      ))}
    </Carousel>
  );
};

export default MovieCarousel;
