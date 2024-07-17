import React from 'react';
import { Movie } from '../interfaces/Movie';

interface MovieCardProps {
  movie: Movie;
  onBuyTicket: (movieId: number) => void;
  onViewDetails: (movieId: number) => void;
}

const MovieCard: React.FC<MovieCardProps> = ({ movie, onBuyTicket, onViewDetails }) => {
  return (
    <div className="movie-card">
      <img src={movie.imageUrl} alt={movie.title} />
      <div className="movie-info">
        <h3>{movie.title}</h3>
        <button onClick={() => onBuyTicket(movie.id)}>Mua vé</button>
        <button onClick={() => onViewDetails(movie.id)}>Xem chi tiết</button>
      </div>
    </div>
  );
};

export default MovieCard;
