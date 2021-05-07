import { useState } from 'react'
import { Heading } from './components/Heading'
import {Article} from './components/Article'

import articles from './articles.json'

export function helperThingy() {
  return "Foo"
}

export function App() {
  let [n, setN] = useState(0)

  return <div>
    <Heading title="Hello, React Page" count={n} />
    <main className="right-stuff">
      <button onClick={() => setN(n + 1)}>
        Click Me
      </button>
    </main>
    <footer>Remember, that time you clicked me {n} times?</footer>
    
    {articles.map((article) => {
      return <Article key={article.id} {...article} />
    })}
  </div>
}
