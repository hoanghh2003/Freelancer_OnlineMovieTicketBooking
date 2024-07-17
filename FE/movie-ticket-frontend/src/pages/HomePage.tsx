import React, { useEffect, useState } from 'react';
import axios from 'axios';
import MovieCard from '../components/MovieCard';
import MovieCarousel from '../components/Carousel';
import '../assets/styles/HomePage.css';
import { Movie, MovieDetails } from '../interfaces/Movie';

const HomePage: React.FC = () => {
  const [movies, setMovies] = useState<Movie[]>([]);
  const [selectedMovie, setSelectedMovie] = useState<MovieDetails | null>(null);
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
      await axios.post('https://localhost:5001/api/tickets', { movieId, buyerName: 'John Doe', purchaseDate: new Date().toISOString() });
      alert('Ticket purchased successfully!');
    } catch (error: any) {
      setError('Failed to buy ticket: ' + error.message);
    }
  };

  const handleViewDetails = async (movieId: number) => {
    try {
      const response = await axios.get(`https://localhost:5001/api/Movies/Details/${movieId}`);
      setSelectedMovie(response.data);
    } catch (error: any) {
      setError('Failed to fetch movie details: ' + error.message);
    }
  };

  return (
    <div className="home-page">
      <MovieCarousel movies={movies} />
      <h1>Now Showing</h1>
      {error && <p style={{ color: 'red' }}>{error}</p>}
      <div className="movie-list">
        {movies.map(movie => (
          <MovieCard key={movie.id} movie={movie} onBuyTicket={handleBuyTicket} onViewDetails={handleViewDetails} />
        ))}
      </div>
      {selectedMovie && (
        <div className="movie-details">
          <h2>{selectedMovie.title}</h2>
          <img src={selectedMovie.imageUrl} alt={selectedMovie.title} />
          <p><strong>Thể loại:</strong> {selectedMovie.genre}</p>
          <p><strong>Mô tả:</strong> {selectedMovie.description}</p>
          <p><strong>Thời lượng:</strong> {selectedMovie.duration}</p>
          <p><strong>Khởi chiếu:</strong> {new Date(selectedMovie.releaseDate).toDateString()}</p>
          <p><strong>Đạo diễn:</strong> {selectedMovie.director}</p>
          <p><strong>Ngôn ngữ:</strong> {selectedMovie.language}</p>
          <p><strong>Diễn viên:</strong> {selectedMovie.actors.join(', ')}</p>
          <p><strong>Rated:</strong> {selectedMovie.rated}</p>
        </div>
      )}
    </div>
  );
};

export default HomePage;
