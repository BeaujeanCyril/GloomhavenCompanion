/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Pages/**/*.{razor,html}", // surveille les fichiers Razor
    "./Shared/**/*.{razor,html}", // surveille les fichiers Razor dans le dossier Shared
    "./wwwroot/**/*.{html,js}"    // surveille les fichiers HTML et JS dans wwwroot
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
