export function Article({ id, title, body }) {
  return (
    <article className="intro-article">
      <h2 className="article-title">{title}</h2>
      <p>{body}</p>
      <a className="read-more" href={`articles/${id}`}>
        Read more about {title}.
      </a>
    </article>
  )
}
