# Tower_Defense
 School project leerjaar 2 periode 1
```mermaid
 graph TD
    A[Start Game] -->|Click Start Wave| B(Spawn Wave)
    B --> C{Shoot Enemy}
    C -->|Enemies dead| A
    C -->|Enemies alive| E[You dead]
