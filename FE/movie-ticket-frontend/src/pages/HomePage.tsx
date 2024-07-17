// src/pages/HomePage.tsx

import React, { useEffect, useState } from 'react';
import axios from 'axios';
import MovieCard from '../components/MovieCard';
import MovieCarousel from '../components/Carousel';
import '../assets/styles/HomePage.css';

interface Movie {
  id: number;
  title: string;
  genre: string;
  releaseDate: string;
  imageUrl: string;
}

const HomePage: React.FC = () => {
  const [movies, setMovies] = useState<Movie[]>([]);
  const [error, setError] = useState<string>('');

  useEffect(() => {
    const fetchMovies = async () => {
      try {
        const response = await axios.get('https://localhost:5001/api/Movies');
        setMovies(response.data);
      } catch (error: any) {
        setError('Failed to fetch movies: ' + error.message);
      }
    };

    fetchMovies();
  }, []);

  const handleBuyTicket = async (movieId: number) => {
    try {
      await axios.post('/api/tickets', { movieId, buyerName: 'John Doe', purchaseDate: new Date().toISOString() });
      alert('Ticket purchased successfully!');
    } catch (error: any) {
      setError('Failed to buy ticket: ' + error.message);
    }
  };

  return (
    <div className="home-page">
      <MovieCarousel movies={movies} />
      <h1>Now Showing</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <div className="movie-list">
        {movies.map(movie => (
          <MovieCard key={movie.id} movie={movie} onBuyTicket={handleBuyTicket} />
        ))}
      </div>
    </div>
  );
};

export default HomePage;
