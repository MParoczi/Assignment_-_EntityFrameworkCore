ALTER TABLE IF EXISTS ONLY public.post DROP CONSTRAINT IF EXISTS fk_post_user_data CASCADE;

DROP TABLE IF EXISTS public.user_data;
DROP SEQUENCE IF EXISTS public.user_id_seq;

DROP TABLE IF EXISTS public.post;
DROP SEQUENCE IF EXISTS public.post_id_seq;

CREATE TABLE user_data (
    id varchar PRIMARY KEY,
    first_name varchar(50) not null,
    last_name varchar(20) not null,
    posts text
);

CREATE TABLE post (
    id varchar PRIMARY KEY,
    user_id varchar not null,
    content text not null
);

ALTER TABLE ONLY post
    ADD CONSTRAINT fk_post_user_data FOREIGN KEY (user_id) REFERENCES user_data(id);
