SET statement_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;


CREATE FUNCTION public.fn_check_statetype() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF NEW."StateType" NOT IN 
	('Accepted', 'Declined', 'Created', 'Hidden', 'Adopted', 'TemporaryAccommodation', 'OnHold') THEN
        RAISE EXCEPTION 'Invalid StateType value: %', NEW."StateType";
    END IF;
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.fn_check_statetype() OWNER TO postgres;

CREATE FUNCTION public.fn_validate_request() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
	account_type INTEGER;
BEGIN
	SELECT acc_type
	INTO account_type
	FROM request r
	JOIN account a ON r.person_req_author = a.person_id_person
	WHERE r.person_req_author = NEW.person_req_author;

	IF account_type <> 0 THEN
		RAISE EXCEPTION 'Invalid account type for author, expected 0 but got: %', account_type;
	END IF;

	RETURN NEW;
END;
$$;


ALTER FUNCTION public.fn_validate_request() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

CREATE TABLE public.account (
    id_acc uuid NOT NULL,
    username character varying(30) NOT NULL,
    email character varying(30) NOT NULL,
    password character varying(64) NOT NULL,
    acc_type integer NOT NULL,
    person_id_person uuid
);


ALTER TABLE public.account OWNER TO postgres;

CREATE TABLE public.address (
    id_adr uuid NOT NULL,
    street character varying(30) NOT NULL,
    number integer NOT NULL,
    city character varying(30) NOT NULL,
    country character varying(30) NOT NULL,
    zipcode integer NOT NULL
);


ALTER TABLE public.address OWNER TO postgres;

CREATE TABLE public.animal (
    id_animal uuid NOT NULL,
    animal_type_id_type uuid NOT NULL,
    name_a character varying(30) NOT NULL,
    age_a integer NOT NULL,
    desc_a character varying(300) NOT NULL
);


ALTER TABLE public.animal OWNER TO postgres;

CREATE TABLE public.animal_type (
    id_animal_type uuid NOT NULL,
    typename character varying(30) NOT NULL,
    breed character varying(30) NOT NULL
);


ALTER TABLE public.animal_type OWNER TO postgres;

CREATE TABLE public.association (
    id_assoc uuid NOT NULL,
    assoc_name character varying(30) NOT NULL,
    assoc_acc_number character varying(20) NOT NULL,
    assoc_website character varying(50)
);


ALTER TABLE public.association OWNER TO postgres;

CREATE TABLE public.comment (
    id_comment uuid NOT NULL,
    person_author_c uuid NOT NULL,
    comment_text character varying(300) NOT NULL
);


ALTER TABLE public.comment OWNER TO postgres;

CREATE TABLE public.notification (
    id_notification uuid NOT NULL,
    id_recipient uuid NOT NULL,
    message character varying(300) NOT NULL
);


ALTER TABLE public.notification OWNER TO postgres;

CREATE TABLE public.offer (
    id_offer uuid NOT NULL,
    person_author_o uuid NOT NULL,
    type_o integer NOT NULL,
    status_o integer NOT NULL
);


ALTER TABLE public.offer OWNER TO postgres;

CREATE TABLE public.person (
    id_person uuid NOT NULL,
    name character varying(30) NOT NULL,
    surname character varying(30) NOT NULL,
    phone character varying(30) NOT NULL,
    gender integer NOT NULL,
    birth date NOT NULL,
    address_id_adr uuid NOT NULL
);


ALTER TABLE public.person OWNER TO postgres;

CREATE TABLE public.photo (
    id_photo uuid NOT NULL,
    photo_url text NOT NULL,
    photo_desc character varying(300) NOT NULL,
    "AnimalId" uuid
);


ALTER TABLE public.photo OWNER TO postgres;

CREATE TABLE public.post (
    id_post uuid NOT NULL,
    person_author_p uuid NOT NULL,
    text_p character varying(300) NOT NULL,
    animal_animal_id uuid NOT NULL,
    creation_date date NOT NULL
);


ALTER TABLE public.post OWNER TO postgres;

CREATE TABLE public.post_comments (
    comment_id_comment uuid NOT NULL,
    post_id_post_cmt uuid NOT NULL
);


ALTER TABLE public.post_comments OWNER TO postgres;

CREATE TABLE public.post_likes (
    person_id_liked uuid NOT NULL,
    post_id_liked uuid NOT NULL
);


ALTER TABLE public.post_likes OWNER TO postgres;

CREATE TABLE public.post_offers (
    offer_id_offer uuid NOT NULL,
    post_id_post uuid NOT NULL
);


ALTER TABLE public.post_offers OWNER TO postgres;

CREATE TABLE public.post_state (
    "Id" uuid NOT NULL,
    "StateType" character varying(34) NOT NULL
);


ALTER TABLE public.post_state OWNER TO postgres;

CREATE TABLE public.request (
    id_req uuid NOT NULL,
    person_req_author uuid NOT NULL,
    creation_date_req date NOT NULL,
    for_promotion integer NOT NULL,
    against_promotion integer NOT NULL
);


ALTER TABLE public.request OWNER TO postgres;

CREATE TABLE public.review (
    id_review uuid NOT NULL,
    grade integer NOT NULL,
    comment_r character varying(300) NOT NULL,
    "OfferId" uuid
);


ALTER TABLE public.review OWNER TO postgres;

CREATE TABLE public.vote (
    person_id_voter uuid NOT NULL,
    request_id_voted uuid NOT NULL,
    voted_for boolean NOT NULL
);


ALTER TABLE public.vote OWNER TO postgres;