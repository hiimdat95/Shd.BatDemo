/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ["./Views/**/*.cshtml", "./Components/**/*.razor"],
    prefix: "tw-",
    theme: {
        container: {
            center: true,
            padding: {
                DEFAULT: "1rem",
            },
        },
        extend: {
            colors: {
                primary: "var(--primary)",
                "primary-hover": "var(--primary-hover)",
                danger: "var(--danger)",
                secondary: "#212529",
            },
        },
    },
    plugins: [],
};
