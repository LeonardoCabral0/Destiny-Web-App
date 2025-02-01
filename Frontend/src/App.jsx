import './App.css'
import { createBrowserRouter, Outlet, RouterProvider } from 'react-router-dom'

import { MenuBar } from './components/MenuBar/MenuBar'
import { HomePage } from './pages/HomePage/HomePage'
import { RegisterPage } from './pages/RegisterPage/RegisterPage'
import { ExplorerPage } from './pages/ExplorePage/ExplorerPage'

function Layout() {
  return (
    <>
      <MenuBar />
      <Outlet />
    </>
  )
}

const router = createBrowserRouter([
  {
    element: <Layout />,
    children: [
      { path: "/", element: <HomePage /> },
      { path: "/cadastro", element: <RegisterPage /> },
      { path: "/explorar", element: <ExplorerPage />}
    ],
  },
]);

function App() {
  return <RouterProvider router={router} />
}

export default App
