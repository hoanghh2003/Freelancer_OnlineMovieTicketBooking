// src/components/MovieCard.tsx
import React from 'react';

interface Movie {
  id: number;
  title: string;
  genre: string;
  releaseDate: string;
  imageUrl: string;
}

interface MovieCardProps {
  movie: Movie;
  onBuyTicket: (movieId: number) => void;
}

const MovieCard: React.FC<MovieCardProps> = ({ movie, onBuyTicket }) => {
  return (
    <div className="movie-card">
      <img src={movie.imageUrl} alt={movie.title} />
      <div className="movie-info">
        <h3>{movie.title}</h3>
        <p>{movie.genre}</p>
        <p>{new Date(movie.releaseDate).toDateString()}</p>
        <button onClick={() => onBuyTicket(movie.id)}>Mua vé</button>
        <button>Xem chi tiết</button>
      </div>
    </div>
  );
};

export default MovieCard;
