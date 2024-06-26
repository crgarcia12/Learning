for now, just testing data structures

# PostgreSQL script
```sql
DROP TABLE IF EXISTS public.concepts;
DROP TABLE IF EXISTS public.questions;
DROP TABLE IF EXISTS public.topics;
DROP TABLE IF EXISTS public.areas;
DROP TABLE IF EXISTS public.trivias;
DROP TABLE IF EXISTS public.trivia_answers;

------------------------------------------------------
-- TABLE: Areas

CREATE TABLE IF NOT EXISTS public.areas
(
    id UUID,
    name TEXT,
    PRIMARY KEY(id)
);

------------------------------------------------------
-- TABLE: Topics

CREATE TABLE IF NOT EXISTS public.topics
(
    id UUID,
    area_id UUID,
    name TEXT,
    
    PRIMARY KEY(id),
    CONSTRAINT fk_AreaId
      FOREIGN KEY(area_id) 
        REFERENCES areas(id)
);
        
------------------------------------------------------
-- TABLE: Concepts
CREATE TABLE IF NOT EXISTS public.concepts
(
    id UUID,
    topic_id UUID,
    name TEXT,
    concept_text TEXT,
    
    PRIMARY KEY(id),
    CONSTRAINT fk_TopicId
      FOREIGN KEY(topic_id) 
        REFERENCES topics(id)
);
    
------------------------------------------------------
-- TABLE: Questions
CREATE TABLE IF NOT EXISTS public.questions
(
    id UUID,
    topic_id UUID,
    question_text TEXT,
    option_correct TEXT,
    option_incorrect_2 TEXT,
    option_incorrect_3 TEXT,
    option_incorrect_4 TEXT,
    
    PRIMARY KEY(id),
    CONSTRAINT fk_TopicId
      FOREIGN KEY(topic_id)
        REFERENCES topics(id)
);

------------------------------------------------------
-- TABLE: Trivia
CREATE TABLE IF NOT EXISTS public.trivias
(
    id UUID,
    topic_id UUID,
    completion_date TIMESTAMP,
    
    PRIMARY KEY(id),
    CONSTRAINT fk_TopicId
      FOREIGN KEY(topic_id)
        REFERENCES topics(id)
);

------------------------------------------------------
-- TABLE: TriviaAnswer
CREATE TABLE IF NOT EXISTS public.trivia_answers
(
    id UUID,
    trivia_id UUID,
    question_id UUID,
    completion_date TIMESTAMP,
    selected_answer INT,

    PRIMARY KEY(id),
    CONSTRAINT fk_TriviaId
      FOREIGN KEY(trivia_id)
        REFERENCES trivias(id),
    CONSTRAINT fk_QuestionId
      FOREIGN KEY(question_id)
        REFERENCES questions(id)
);
```