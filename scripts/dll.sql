--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-07-05 11:41:52

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 235 (class 1255 OID 18157)
-- Name: fn_check_statetype(); Type: FUNCTION; Schema: public; Owner: postgres
--

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

--
-- TOC entry 234 (class 1255 OID 18162)
-- Name: fn_validate_request(); Type: FUNCTION; Schema: public; Owner: postgres
--

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

--
-- TOC entry 215 (class 1259 OID 17958)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 17993)
-- Name: account; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.account (
    id_acc uuid NOT NULL,
    username character varying(30) NOT NULL,
    email character varying(30) NOT NULL,
    password character varying(64) NOT NULL,
    acc_type integer NOT NULL,
    person_id_person uuid
);


ALTER TABLE public.account OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 17963)
-- Name: address; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.address (
    id_adr uuid NOT NULL,
    street character varying(30) NOT NULL,
    number integer NOT NULL,
    city character varying(30) NOT NULL,
    country character varying(30) NOT NULL,
    zipcode integer NOT NULL
);


ALTER TABLE public.address OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 17983)
-- Name: animal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.animal (
    id_animal uuid NOT NULL,
    animal_type_id_type uuid NOT NULL,
    name_a character varying(30) NOT NULL,
    age_a integer NOT NULL,
    desc_a character varying(300) NOT NULL
);


ALTER TABLE public.animal OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 17968)
-- Name: animal_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.animal_type (
    id_animal_type uuid NOT NULL,
    typename character varying(30) NOT NULL,
    breed character varying(30) NOT NULL
);


ALTER TABLE public.animal_type OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 18179)
-- Name: association; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.association (
    id_assoc uuid NOT NULL,
    assoc_name character varying(30) NOT NULL,
    assoc_acc_number character varying(20) NOT NULL,
    assoc_website character varying(50)
);


ALTER TABLE public.association OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 18003)
-- Name: comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment (
    id_comment uuid NOT NULL,
    person_author_c uuid NOT NULL,
    comment_text character varying(300) NOT NULL
);


ALTER TABLE public.comment OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 18167)
-- Name: notification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.notification (
    id_notification uuid NOT NULL,
    id_recipient uuid NOT NULL,
    message character varying(300) NOT NULL
);


ALTER TABLE public.notification OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 18013)
-- Name: offer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.offer (
    id_offer uuid NOT NULL,
    person_author_o uuid NOT NULL,
    type_o integer NOT NULL,
    status_o integer NOT NULL
);


ALTER TABLE public.offer OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 17973)
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

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

--
-- TOC entry 224 (class 1259 OID 18033)
-- Name: photo; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.photo (
    id_photo uuid NOT NULL,
    photo_url text NOT NULL,
    photo_desc character varying(300) NOT NULL,
    "AnimalId" uuid
);


ALTER TABLE public.photo OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 18045)
-- Name: post; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.post (
    id_post uuid NOT NULL,
    person_author_p uuid NOT NULL,
    text_p character varying(300) NOT NULL,
    animal_animal_id uuid NOT NULL,
    creation_date date NOT NULL
);


ALTER TABLE public.post OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 18085)
-- Name: post_comments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.post_comments (
    comment_id_comment uuid NOT NULL,
    post_id_post_cmt uuid NOT NULL
);


ALTER TABLE public.post_comments OWNER TO postgres;

--
-- TOC entry 229 (class 1259 OID 18100)
-- Name: post_likes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.post_likes (
    person_id_liked uuid NOT NULL,
    post_id_liked uuid NOT NULL
);


ALTER TABLE public.post_likes OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 18115)
-- Name: post_offers; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.post_offers (
    offer_id_offer uuid NOT NULL,
    post_id_post uuid NOT NULL
);


ALTER TABLE public.post_offers OWNER TO postgres;

--
-- TOC entry 231 (class 1259 OID 18130)
-- Name: post_state; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.post_state (
    "Id" uuid NOT NULL,
    "StateType" character varying(34) NOT NULL
);


ALTER TABLE public.post_state OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 18023)
-- Name: request; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.request (
    id_req uuid NOT NULL,
    person_req_author uuid NOT NULL,
    creation_date_req date NOT NULL,
    for_promotion integer NOT NULL,
    against_promotion integer NOT NULL
);


ALTER TABLE public.request OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 18060)
-- Name: review; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.review (
    id_review uuid NOT NULL,
    grade integer NOT NULL,
    comment_r character varying(300) NOT NULL,
    "OfferId" uuid
);


ALTER TABLE public.review OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 18070)
-- Name: vote; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.vote (
    person_id_voter uuid NOT NULL,
    request_id_voted uuid NOT NULL,
    voted_for boolean NOT NULL
);


ALTER TABLE public.vote OWNER TO postgres;

--
-- TOC entry 4929 (class 0 OID 17958)
-- Dependencies: 215
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240701100756_Initial	8.0.6
20240702210817_Validation	8.0.6
20240703162751_Notifications	8.0.6
20240703165331_Associations	8.0.6
\.


--
-- TOC entry 4934 (class 0 OID 17993)
-- Dependencies: 220
-- Data for Name: account; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.account (id_acc, username, email, password, acc_type, person_id_person) FROM stdin;
e6246276-9ea7-4479-b6d8-87bdc825adcb	ilija	ilija@gmail.com	47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=	1	4f374181-a9e9-41b7-b720-9cc482197c66
3cc22e32-c192-4cea-ab65-e6f2cb8eb0f4	vuk	vuk@gmail.com	47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=	0	64e5676e-fdfa-4015-b62f-c3da5d3ee32d
d5028494-6654-4186-9cdd-94702c2e16e4	TestAcc	testacc@gmail.com	123	2	246711ac-0359-433f-a279-8d1edefbeee1
d1138e33-6a17-4379-ab02-6c07cd006a83	testuser	email@email.com	zdnfQa3Mv16Fis1IKCr9fOFa8/4+5Yfq0Tg/tpFYUXw=	1	cb131749-5857-43f9-be1b-e8a74aa66d1a
f950e797-10c0-4231-8d26-66ffb7cbf1cf	peraaa	pera@gmail.com	pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=	0	dbadb17b-9d27-4e4a-9e67-91872281767b
4f638144-85a6-11ec-b909-0242ac120002	johndoe	john@example.com	9b1de1fce0c2e5971ee6f3bd0e1c88a0cf8e76e09f3f4a3f6d50d3bb1f1c7c5a	1	4f638094-85a6-11ec-b909-0242ac120002
4f638170-85a6-11ec-b909-0242ac120002	janesmith	jane@example.com	e8c3b208f7383b4efb6ffb91d5a3b8241d96b54c03b7561f4e9b5f3e237e35c1	2	4f6380c0-85a6-11ec-b909-0242ac120002
4f63819c-85a6-11ec-b909-0242ac120002	alicej	alice@example.com	b7e23ec29af22b0b4e41da31e868d57226121c84b07f7d4f67c5e2d76f6e2453	1	4f6380ec-85a6-11ec-b909-0242ac120002
4f6381c8-85a6-11ec-b909-0242ac120002	bobbrown	bob@example.com	3c3d1d3e9e833bc9c37ef4f13b4d4cb5e16e72d3e6e8c5a1f81e18a4566c4f79	2	4f638118-85a6-11ec-b909-0242ac120002
f5b4aa72-51f1-4813-a378-b5a84bd0e9fd	lazar	lazar@gmail.com	47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=	2	3207abde-c1cb-493c-95d4-c1914683207a
7d7d9143-0716-4a30-acc1-89bcfc0336ee	testic	test@gmail.com	pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=	1	e2bf96ef-3ac9-486f-a7e1-f614b6adddd9
\.


--
-- TOC entry 4930 (class 0 OID 17963)
-- Dependencies: 216
-- Data for Name: address; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.address (id_adr, street, number, city, country, zipcode) FROM stdin;
f367f088-fcbe-4758-9a93-453343b8fb6d	ulica	1	Sombor	Srbija	25000
f6921df4-380c-488f-804f-c68544bf394b	ulica	1	Sombor	Srbija	25000
5f6ef489-9fcf-4e57-bb10-f1555ca6b45c	ulica	1	Sombor	Srbija	25000
54b87dec-8de9-43fb-ae44-bc77b9840af1	neka	1	neki	neka	31233
5d7ba1da-0c07-4909-ab05-110eea65da57	neka	1	neki	neka	31233
0eca5883-f718-4e34-946d-a93bf41c0e52	ulica	10	Sombor	Srbija	25000
cc3aab6e-9068-4e5c-b223-ccf7f1c77b5c	Perina ulica	25	Perinov grad	Tunguzija	42069
c2687397-bfc2-491d-a0aa-03abd4d70aac	Perina ulica	12	Novi Sad	Srbija	21000
4f637e64-85a6-11ec-b909-0242ac120002	Main St	123	Springfield	USA	12345
4f637e90-85a6-11ec-b909-0242ac120002	Elm St	456	Shelbyville	USA	67890
4f637ebc-85a6-11ec-b909-0242ac120002	Oak St	789	Capital City	USA	54321
4f637ee8-85a6-11ec-b909-0242ac120002	Pine St	101	Ogdenville	USA	98765
73b0767a-6b59-4bea-af2b-b41e5d67e4b1	Filipa Tota	10	Sombor	Srbija	25000
d645662a-d3ff-467a-9586-870001b99541	Filipa Tota	10	Sombor	Srbija	25000
db4860fb-6613-4d80-85f9-cb3f8529a7e0	Filipa Tota	10	Sombor	Srbija	25000
c90e24de-1ac4-4ee4-a674-32837ee8d2cb	Filipa Tota	10	Sombor	Srbija	25000
16ce87a7-1df0-4a0f-8432-533b74f3c635	Filipa Tota	10	Sombor	Srbija	25000
ad42f6ef-dfe6-46b8-a9ad-a53d694e8285	Filipa Tota	10	Sombor	Srbija	25000
057b1a05-4e09-4c5e-b7a3-f3c2f244f117	Filipa Tota	10	Sombor	Srbija	25000
e26a6011-948b-4163-ad9c-f4134524ec37	Filipa Tota	10	Sombor	Srbija	25000
8bde475e-9d5c-4d37-802e-8b69731dd3a6	Filipa Tota	10	Sombor	Srbija	25000
d1614c03-9ef5-45a1-9b6b-543f9fab6e35	Ilijina ulica	15	Ilijingrad	Srbija	151515
6ff497fe-dcad-4f96-899a-d4907bb32612	Ilijina ulica	15	Ilijingrad	Srbija	151515
519dc5b4-fb6d-4a08-af49-12da665952f6	Vukova	15	Novi Sad	Srbija	21000
fc81c806-8127-4846-86af-6ee57131efd4	testiceva	10	Testcity	Testonija	22452
\.


--
-- TOC entry 4933 (class 0 OID 17983)
-- Dependencies: 219
-- Data for Name: animal; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.animal (id_animal, animal_type_id_type, name_a, age_a, desc_a) FROM stdin;
01b93126-71e6-455f-8f5c-b97c69733a46	682c7929-7cd6-4511-97e6-bff7ba7e3134	pera	10	opis
2187170a-da18-41e3-b9c8-10ec7e375b59	682c7929-7cd6-4511-97e6-bff7ba7e3134	Pera	2	Lorem Ipsum is simply dummy te
bf6a5346-0c0e-4d37-a177-adcb040fef58	682c7929-7cd6-4511-97e6-bff7ba7e3134	Pera	2	Lorem Ipsum is simply dummy te
e4b7d39a-4bc4-4297-8d8e-276d8e491567	682c7929-7cd6-4511-97e6-bff7ba7e3134	Filip	4	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus metus arcu, ornare quis ullamcorper ut, finibus sed dolor. Donec egestas diam eu mi fringilla luctus. Sed eget leo consequat, semper velit sed, tincidunt eros. Fusce faucibus felis sed sapien cursus, et mollis tellus elementum. Donec
860b3181-3e1e-4496-852d-6e0b80c5b142	682c7929-7cd6-4511-97e6-bff7ba7e3134	Pera	5	Etiam ultricies luctus nunc, vitae bibendum mi posuere nec. Phasellus commodo magna non viverra ultrices. Quisque non massa eros. Cras elementum varius dui id rutrum. Curabitur vel sollicitudin diam. Pellentesque congue sollicitudin diam, quis tristique nisl eleifend sit amet. Suspendisse ultrices a
4f295767-5545-42e3-9f7f-ae53fcffe3a1	682c7929-7cd6-4511-97e6-bff7ba7e3134	Filip	10	Phasellus sagittis porttitor porta. Aliquam sit amet lectus nibh. Phasellus accumsan, quam ac egestas gravida, nibh orci egestas ex, quis auctor felis purus eu risus. Mauris sodales sodales blandit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In vita
db2c788f-1769-456e-b45e-e75ce6c9c28c	682c7929-7cd6-4511-97e6-bff7ba7e3134	Petar	10	Phasellus sagittis porttitor porta. Aliquam sit amet lectus nibh. Phasellus accumsan, quam ac egestas gravida, nibh orci egestas ex, quis auctor felis purus eu risus. Mauris sodales sodales blandit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In vita
c9e3a181-dbc5-4d07-9c16-dd8d13530986	682c7929-7cd6-4511-97e6-bff7ba7e3134	Lazar	21	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus metus arcu, ornare quis ullamcorper ut, finibus sed dolor. Donec egestas diam eu mi fringilla luctus. Sed eget leo consequat, semper velit sed, tincidunt eros. Fusce faucibus felis sed sapien cursus, et mollis tellus elementum. Donec
9026ee84-f061-4193-a36a-cc9aa09fcc8d	682c7929-7cd6-4511-97e6-bff7ba7e3134	Luka	10	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.
6eedf620-cc74-435b-9f99-9d81c9c8bf5a	682c7929-7cd6-4511-97e6-bff7ba7e3134	Lora	10	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.
d4bd82bb-76af-4b37-ae3b-bcc1416c8b5c	682c7929-7cd6-4511-97e6-bff7ba7e3134	FSAFASF	10	FASFAF
4f6380ec-85a6-11ec-b909-0242ac120002	4f637f20-85a6-11ec-b909-0242ac120002	Buddy	3	Friendly dog
4f638118-85a6-11ec-b909-0242ac120002	4f637f4c-85a6-11ec-b909-0242ac120002	Whiskers	2	Curious cat
4f6384f8-85a6-11ec-b909-0242ac120002	4f637f78-85a6-11ec-b909-0242ac120002	Polly	4	Colorful parrot
4f638514-85a6-11ec-b909-0242ac120002	4f637fa4-85a6-11ec-b909-0242ac120002	Max	5	Energetic rabbit
4f638530-85a6-11ec-b909-0242ac120002	4f637f4c-85a6-11ec-b909-0242ac120002	Fluffy	3	Playful hamster
a566f054-d622-4a75-9880-356ef9e5b1b4	4f637f4c-85a6-11ec-b909-0242ac120002	fasf	10	asfasfasf
3cbe1db0-122d-4429-981f-600cb4455f74	4f637f4c-85a6-11ec-b909-0242ac120002	fasfa	10	fasfasfas
\.


--
-- TOC entry 4931 (class 0 OID 17968)
-- Dependencies: 217
-- Data for Name: animal_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.animal_type (id_animal_type, typename, breed) FROM stdin;
682c7929-7cd6-4511-97e6-bff7ba7e3134	test	test
4f637f20-85a6-11ec-b909-0242ac120002	Dog	Labrador
4f637f4c-85a6-11ec-b909-0242ac120002	Cat	Siamese
4f637f78-85a6-11ec-b909-0242ac120002	Bird	Parrot
4f637fa4-85a6-11ec-b909-0242ac120002	Rabbit	Angora
a3961501-09f8-4ea8-b422-4432213eb666	Dog	Sicu
\.


--
-- TOC entry 4947 (class 0 OID 18179)
-- Dependencies: 233
-- Data for Name: association; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.association (id_assoc, assoc_name, assoc_acc_number, assoc_website) FROM stdin;
4f638118-85a6-11ec-b909-0242ac120069	Pet center	ACCT-1234567890	www.petcenter.rs
\.


--
-- TOC entry 4935 (class 0 OID 18003)
-- Dependencies: 221
-- Data for Name: comment; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comment (id_comment, person_author_c, comment_text) FROM stdin;
c16f81a6-79a6-4796-a798-8826224e177d	246711ac-0359-433f-a279-8d1edefbeee1	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
c16f81a6-79a6-4796-a798-8826224a177c	246711ac-0359-433f-a279-8d1edefbeee1	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
c16f81a6-79a6-4796-a798-8826224e177c	246711ac-0359-433f-a279-8d1edefbeee1	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
1923becf-0fe4-44b0-9c8b-c022b5fab4f5	246711ac-0359-433f-a279-8d1edefbeee1	
3800677e-66f0-467a-9e82-a9f0bceaaf99	246711ac-0359-433f-a279-8d1edefbeee1	Veoma bitna životinja za prodaju. Bla Bla Bla.
93b5f286-dc83-4aeb-92d9-8e4d42dced4e	246711ac-0359-433f-a279-8d1edefbeee1	Veoma bitna životinja za prodaju. Bla Bla Bla.
c24f690b-9104-45ff-92c6-167e0e024945	246711ac-0359-433f-a279-8d1edefbeee1	Veoma bitna životinja za prodaju. Bla Bla Bla.
26c02d1e-6356-4af0-b32b-59c36fb6033b	246711ac-0359-433f-a279-8d1edefbeee1	
c16f81a6-79a6-4790-a798-8826224e177c	246711ac-0359-433f-a279-8d1edefbeee1	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
c16f81a6-79a6-4740-a798-8826224e1779	cb131749-5857-43f9-be1b-e8a74aa66d1a	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
c16f8146-79a6-4790-a798-8826224e177c	246711ac-0359-433f-a279-8d1edefbeee1	It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum 
f6573502-82c0-4f58-a6fc-05a7598493f5	3207abde-c1cb-493c-95d4-c1914683207a	Dodacu komentar
155e0582-06f7-44e9-8198-ae721249a44f	dbadb17b-9d27-4e4a-9e67-91872281767b	Jos jedan komentar
4f6381f4-85a6-11ec-b909-0242ac120002	4f638094-85a6-11ec-b909-0242ac120002	Great post!
4f638220-85a6-11ec-b909-0242ac120002	4f6380c0-85a6-11ec-b909-0242ac120002	Interesting read.
4f63824c-85a6-11ec-b909-0242ac120002	4f6380ec-85a6-11ec-b909-0242ac120002	Very informative.
4f638278-85a6-11ec-b909-0242ac120002	4f638118-85a6-11ec-b909-0242ac120002	Thanks for sharing.
9997f6b2-281b-4a61-ad4b-03a8ed41cc31	4f374181-a9e9-41b7-b720-9cc482197c66	Lep papagaj
\.


--
-- TOC entry 4946 (class 0 OID 18167)
-- Dependencies: 232
-- Data for Name: notification; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.notification (id_notification, id_recipient, message) FROM stdin;
7685643c-cad4-46c8-92ae-acb8ce65bc7e	dbadb17b-9d27-4e4a-9e67-91872281767b	Congratulations, you animal Lora got adopted by ilija! You should contact them using 12346344142.
8df1c62e-debb-4ce4-8ea6-861f0cee4dca	4f6380c0-85a6-11ec-b909-0242ac120002	Congratulations, you animal Whiskers got temporary accommodation from ilija! You should contact them using 12346344142.
e177f130-1a32-4d8d-8365-ce0235947612	4f6380ec-85a6-11ec-b909-0242ac120002	Congratulations, you animal Polly got temporary accommodation from ilija! You should contact them using 12346344142.
beca92f2-afae-4ef6-bcc4-f2d8ac2fcc43	3207abde-c1cb-493c-95d4-c1914683207a	Congratulations, you animal Lazar got adopted by ilija! You should contact them using 12346344142.
8a54d17b-2199-47f0-83ba-3fca885db25b	64e5676e-fdfa-4015-b62f-c3da5d3ee32d	Unfortunately, your Adoption offer for ilija's animal fasfa was rejected.
\.


--
-- TOC entry 4936 (class 0 OID 18013)
-- Dependencies: 222
-- Data for Name: offer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.offer (id_offer, person_author_o, type_o, status_o) FROM stdin;
cb131749-5857-43f9-be1b-e8a74aa66d99	cb131749-5857-43f9-be1b-e8a74aa66d1a	0	0
4d8baf99-c73b-499f-9202-1397b6266334	4f374181-a9e9-41b7-b720-9cc482197c66	1	0
79a23080-beab-4bdd-8d74-c5e783ad2c67	4f374181-a9e9-41b7-b720-9cc482197c66	0	0
198b4dcb-9300-4d86-9f51-605448ff1df9	4f374181-a9e9-41b7-b720-9cc482197c66	0	1
04081db4-1d41-49a1-bc3a-c9346cb8d7a9	4f374181-a9e9-41b7-b720-9cc482197c66	0	0
6400c69e-6a5e-4675-8bc1-0e92c416d582	4f374181-a9e9-41b7-b720-9cc482197c66	1	1
43e4793e-f1a9-42d9-89bf-af5c2900819f	4f374181-a9e9-41b7-b720-9cc482197c66	1	1
148051ea-8ac5-4647-820b-d725cc89594b	4f374181-a9e9-41b7-b720-9cc482197c66	1	0
dce21e84-9ea0-4bc9-8034-8c6e0a349153	4f374181-a9e9-41b7-b720-9cc482197c66	0	1
cebc532d-e884-4592-a4a5-eba69b27df7d	4f374181-a9e9-41b7-b720-9cc482197c66	1	0
69e811d7-e0e3-47c3-b9a9-d64f0cbce340	64e5676e-fdfa-4015-b62f-c3da5d3ee32d	0	2
\.


--
-- TOC entry 4932 (class 0 OID 17973)
-- Dependencies: 218
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.person (id_person, name, surname, phone, gender, birth, address_id_adr) FROM stdin;
cb131749-5857-43f9-be1b-e8a74aa66d1a	Test	User	11232414214	1	2014-07-01	5d7ba1da-0c07-4909-ab05-110eea65da57
246711ac-0359-433f-a279-8d1edefbeee1	tester	test	1234567890	0	-infinity	5f6ef489-9fcf-4e57-bb10-f1555ca6b45c
3207abde-c1cb-493c-95d4-c1914683207a	Lazar	Nagulov	12213123123	0	2003-04-30	0eca5883-f718-4e34-946d-a93bf41c0e52
3467d9bc-abd6-4d06-bcca-23b88570fdc1	Pera	Peric	1234567789	0	-infinity	cc3aab6e-9068-4e5c-b223-ccf7f1c77b5c
dbadb17b-9d27-4e4a-9e67-91872281767b	Pera	Peric	123452342	0	-infinity	c2687397-bfc2-491d-a0aa-03abd4d70aac
4f638094-85a6-11ec-b909-0242ac120002	John	Doe	555-1234	1	1980-01-01	4f637e64-85a6-11ec-b909-0242ac120002
4f6380c0-85a6-11ec-b909-0242ac120002	Jane	Smith	555-5678	2	1990-02-02	4f637e90-85a6-11ec-b909-0242ac120002
4f6380ec-85a6-11ec-b909-0242ac120002	Alice	Johnson	555-8765	2	1975-03-03	4f637ebc-85a6-11ec-b909-0242ac120002
4f638118-85a6-11ec-b909-0242ac120002	Bob	Brown	555-4321	1	1985-04-04	4f637ee8-85a6-11ec-b909-0242ac120002
18c3ae56-da3f-48ce-9bed-7405acc46865	Filip	Tot	1234567890	0	-infinity	73b0767a-6b59-4bea-af2b-b41e5d67e4b1
b7fe432c-a25e-4340-b139-67a87f1e751e	Ilija	Jordanovski	12346344142	0	-infinity	d1614c03-9ef5-45a1-9b6b-543f9fab6e35
4f374181-a9e9-41b7-b720-9cc482197c66	Ilija	Jordanovski	12346344142	0	-infinity	6ff497fe-dcad-4f96-899a-d4907bb32612
64e5676e-fdfa-4015-b62f-c3da5d3ee32d	Vuk	Vicentic	31231231231	0	2024-08-03	519dc5b4-fb6d-4a08-af49-12da665952f6
e2bf96ef-3ac9-486f-a7e1-f614b6adddd9	Test	Test	132131241	1	2024-08-03	fc81c806-8127-4846-86af-6ee57131efd4
\.


--
-- TOC entry 4938 (class 0 OID 18033)
-- Dependencies: 224
-- Data for Name: photo; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.photo (id_photo, photo_url, photo_desc, "AnimalId") FROM stdin;
1062b359-fd9c-4946-9556-102571a1d69a	https://njuska.com/wp-content/uploads/2013/11/animalyoudontknow_wcth18.jpg	Opis slike	01b93126-71e6-455f-8f5c-b97c69733a46
1062b359-fd9c-5946-9556-102571a1d69a	https://srednjeskole.edukacija.rs/wp-content/uploads/2017/01/crvena-panda-890x395_c.jpg	Ponovan opis slike	01b93126-71e6-455f-8f5c-b97c69733a46
9962b359-fd9c-4946-9556-102571a1d69a	https://wannabemagazine.com/wp-content/uploads/2012/02/Slika33.jpg	Veoma bitna životinja za prodaju. Bla Bla Bla.Veoma bitna životinja za prodaju. Bla Bla Bla.Veoma bitna životinja za prodaju. Bla Bla Bla.	01b93126-71e6-455f-8f5c-b97c69733a46
7e02385a-f254-42f4-9191-512b9468797e	https://media.wired.com/photos/593261cab8eb31692072f129/master/pass/85120553.jpg	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 15	2187170a-da18-41e3-b9c8-10ec7e375b59
946d9325-b42d-4eb6-b0e0-87419ab3075a	https://images.pexels.com/photos/47547/squirrel-animal-cute-rodents-47547.jpeg?cs=srgb&dl=pexels-pixabay-47547.jpg&fm=jpg	Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s,Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 15	bf6a5346-0c0e-4d37-a177-adcb040fef58
2a63d627-5d1d-4554-91fe-3bfa58096037	https://aldf.org/wp-content/uploads/fly-images/4076/lamb-iStock-665494268-16x9-e1559777676675-640x360-c.jpg	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus metus arcu, ornare quis ullamcorper ut, finibus sed dolor. Donec egestas diam eu mi fringilla luctus. Sed eget leo consequat, semper velit sed, tincidunt eros. Fusce faucibus felis sed sapien cursus, et mollis tellus elementum. Donec	e4b7d39a-4bc4-4297-8d8e-276d8e491567
827ef145-6a1e-4e44-849a-3d0021a48639	https://aldf.org/wp-content/uploads/fly-images/4076/lamb-iStock-665494268-16x9-e1559777676675-640x360-c.jpg	Phasellus sagittis porttitor porta. Aliquam sit amet lectus nibh. Phasellus accumsan, quam ac egestas gravida, nibh orci egestas ex, quis auctor felis purus eu risus. Mauris sodales sodales blandit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In vita	860b3181-3e1e-4496-852d-6e0b80c5b142
d9a49855-74f1-467f-8ef4-f8dec66ea143	https://aldf.org/wp-content/uploads/fly-images/4076/lamb-iStock-665494268-16x9-e1559777676675-640x360-c.jpg	Phasellus sagittis porttitor porta. Aliquam sit amet lectus nibh. Phasellus accumsan, quam ac egestas gravida, nibh orci egestas ex, quis auctor felis purus eu risus. Mauris sodales sodales blandit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In vita	4f295767-5545-42e3-9f7f-ae53fcffe3a1
f7cc6b0d-7495-4f84-9ce1-1e4b91d1bde6	https://d1jyxxz9imt9yb.cloudfront.net/medialib/4350/image/s768x1300/AdobeStock_123823873_433578_reduced.jpg	Phasellus sagittis porttitor porta. Aliquam sit amet lectus nibh. Phasellus accumsan, quam ac egestas gravida, nibh orci egestas ex, quis auctor felis purus eu risus. Mauris sodales sodales blandit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In vita	db2c788f-1769-456e-b45e-e75ce6c9c28c
61ace57c-1fd9-41c0-8f52-d5f94149c950	https://i.natgeofe.com/k/c02b35d2-bfd7-4ed9-aad4-8e25627cd481/komodo-dragon-head-on_4x3.jpg	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus metus arcu, ornare quis ullamcorper ut, finibus sed dolor. Donec egestas diam eu mi fringilla luctus. Sed eget leo consequat, semper velit sed, tincidunt eros. Fusce faucibus felis sed sapien cursus, et mollis tellus elementum. Donec	c9e3a181-dbc5-4d07-9c16-dd8d13530986
3e00401f-31b9-42d2-8855-e96d7182ea48	https://media.newyorker.com/photos/62c4511e47222e61f46c2daa/4:3/w_2663,h_1997,c_limit/shouts-animals-watch-baby-hemingway.jpg	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.	9026ee84-f061-4193-a36a-cc9aa09fcc8d
215502a1-4781-4500-b9d4-75d693aeb4a8	https://www.dogster.com/wp-content/uploads/2024/01/Labrador-Retriever-dog-standing-on-the-lawn_Radomir-Rezny_Shutterstock.jpg	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.	6eedf620-cc74-435b-9f99-9d81c9c8bf5a
76119056-4eeb-4ff0-91c0-ccfc1d4f9b85	https://zoovrtvrnjci.com/wp-content/uploads/2023/04/gnu.jpg	fafsafa	d4bd82bb-76af-4b37-ae3b-bcc1416c8b5c
4f6382fc-85a6-11ec-b909-0242ac120002	https://example.com/photo1.jpg	Cute puppy	4f6380ec-85a6-11ec-b909-0242ac120002
4f638328-85a6-11ec-b909-0242ac120002	https://example.com/photo2.jpg	Beautiful kitten	4f638118-85a6-11ec-b909-0242ac120002
4f638354-85a6-11ec-b909-0242ac120002	https://example.com/photo3.jpg	Colorful parrot	4f6384f8-85a6-11ec-b909-0242ac120002
4f638380-85a6-11ec-b909-0242ac120002	https://example.com/photo4.jpg	Energetic rabbit	4f638514-85a6-11ec-b909-0242ac120002
\.


--
-- TOC entry 4939 (class 0 OID 18045)
-- Dependencies: 225
-- Data for Name: post; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.post (id_post, person_author_p, text_p, animal_animal_id, creation_date) FROM stdin;
832af3a4-fbe6-43ce-80ca-49c422f8413c	3207abde-c1cb-493c-95d4-c1914683207a	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus metus arcu, ornare quis ullamcorper ut, finibus sed dolor. Donec egestas diam eu mi fringilla luctus. Sed eget leo consequat, semper velit sed, tincidunt eros. Fusce faucibus felis sed sapien cursus, et mollis tellus elementum. Donec	c9e3a181-dbc5-4d07-9c16-dd8d13530986	2024-07-03
bf2147c6-c5eb-4e5b-9b6f-2618094d572e	3207abde-c1cb-493c-95d4-c1914683207a	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.	9026ee84-f061-4193-a36a-cc9aa09fcc8d	2024-07-04
124678de-78ec-4616-bbfb-f0e7161d8411	dbadb17b-9d27-4e4a-9e67-91872281767b	Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi odio arcu, rhoncus non mollis ac, commodo vitae felis. Donec nec tincidunt arcu. Suspendisse eleifend sodales ligula, eget tristique libero facilisis a. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia et.	6eedf620-cc74-435b-9f99-9d81c9c8bf5a	2024-07-04
ecbf912e-ea64-4481-a9c1-1571ef277c91	3207abde-c1cb-493c-95d4-c1914683207a	dIOADHodhAD	d4bd82bb-76af-4b37-ae3b-bcc1416c8b5c	2024-07-04
4f6383e0-85a6-11ec-b909-0242ac120002	4f638094-85a6-11ec-b909-0242ac120002	Check out my new puppy!	4f6380ec-85a6-11ec-b909-0242ac120002	2022-01-01
4f63840c-85a6-11ec-b909-0242ac120002	4f6380c0-85a6-11ec-b909-0242ac120002	Look at my kitten!	4f638118-85a6-11ec-b909-0242ac120002	2022-02-02
4f638438-85a6-11ec-b909-0242ac120002	4f6380ec-85a6-11ec-b909-0242ac120002	My parrot is so colorful!	4f6384f8-85a6-11ec-b909-0242ac120002	2022-03-03
4f638464-85a6-11ec-b909-0242ac120002	4f638118-85a6-11ec-b909-0242ac120002	My rabbit is full of energy!	4f638514-85a6-11ec-b909-0242ac120002	2022-04-04
703226e3-bffe-44ed-be18-8e54a9f1e3e5	64e5676e-fdfa-4015-b62f-c3da5d3ee32d	afasfasf	a566f054-d622-4a75-9880-356ef9e5b1b4	2024-07-05
84d06571-2523-4c80-b7eb-508bbbd32b2e	4f374181-a9e9-41b7-b720-9cc482197c66	fasfasf	3cbe1db0-122d-4429-981f-600cb4455f74	2024-07-05
\.


--
-- TOC entry 4942 (class 0 OID 18085)
-- Dependencies: 228
-- Data for Name: post_comments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.post_comments (comment_id_comment, post_id_post_cmt) FROM stdin;
f6573502-82c0-4f58-a6fc-05a7598493f5	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
155e0582-06f7-44e9-8198-ae721249a44f	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
9997f6b2-281b-4a61-ad4b-03a8ed41cc31	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
\.


--
-- TOC entry 4943 (class 0 OID 18100)
-- Dependencies: 229
-- Data for Name: post_likes; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.post_likes (person_id_liked, post_id_liked) FROM stdin;
3207abde-c1cb-493c-95d4-c1914683207a	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
dbadb17b-9d27-4e4a-9e67-91872281767b	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
3207abde-c1cb-493c-95d4-c1914683207a	124678de-78ec-4616-bbfb-f0e7161d8411
3207abde-c1cb-493c-95d4-c1914683207a	4f638438-85a6-11ec-b909-0242ac120002
4f374181-a9e9-41b7-b720-9cc482197c66	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
\.


--
-- TOC entry 4944 (class 0 OID 18115)
-- Dependencies: 230
-- Data for Name: post_offers; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.post_offers (offer_id_offer, post_id_post) FROM stdin;
cb131749-5857-43f9-be1b-e8a74aa66d99	bf2147c6-c5eb-4e5b-9b6f-2618094d572e
198b4dcb-9300-4d86-9f51-605448ff1df9	124678de-78ec-4616-bbfb-f0e7161d8411
4d8baf99-c73b-499f-9202-1397b6266334	124678de-78ec-4616-bbfb-f0e7161d8411
79a23080-beab-4bdd-8d74-c5e783ad2c67	124678de-78ec-4616-bbfb-f0e7161d8411
6400c69e-6a5e-4675-8bc1-0e92c416d582	4f63840c-85a6-11ec-b909-0242ac120002
04081db4-1d41-49a1-bc3a-c9346cb8d7a9	4f63840c-85a6-11ec-b909-0242ac120002
43e4793e-f1a9-42d9-89bf-af5c2900819f	4f638438-85a6-11ec-b909-0242ac120002
dce21e84-9ea0-4bc9-8034-8c6e0a349153	832af3a4-fbe6-43ce-80ca-49c422f8413c
148051ea-8ac5-4647-820b-d725cc89594b	832af3a4-fbe6-43ce-80ca-49c422f8413c
cebc532d-e884-4592-a4a5-eba69b27df7d	703226e3-bffe-44ed-be18-8e54a9f1e3e5
69e811d7-e0e3-47c3-b9a9-d64f0cbce340	84d06571-2523-4c80-b7eb-508bbbd32b2e
\.


--
-- TOC entry 4945 (class 0 OID 18130)
-- Dependencies: 231
-- Data for Name: post_state; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.post_state ("Id", "StateType") FROM stdin;
4f6383e0-85a6-11ec-b909-0242ac120002	Declined
bf2147c6-c5eb-4e5b-9b6f-2618094d572e	Adopted
124678de-78ec-4616-bbfb-f0e7161d8411	Adopted
4f63840c-85a6-11ec-b909-0242ac120002	TemporaryAccommodation
4f638438-85a6-11ec-b909-0242ac120002	TemporaryAccommodation
832af3a4-fbe6-43ce-80ca-49c422f8413c	Adopted
84d06571-2523-4c80-b7eb-508bbbd32b2e	Accepted
ecbf912e-ea64-4481-a9c1-1571ef277c91	Declined
703226e3-bffe-44ed-be18-8e54a9f1e3e5	Accepted
\.


--
-- TOC entry 4937 (class 0 OID 18023)
-- Dependencies: 223
-- Data for Name: request; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.request (id_req, person_req_author, creation_date_req, for_promotion, against_promotion) FROM stdin;
6969abde-c1cb-493c-95d4-c1914683207a	cb131749-5857-43f9-be1b-e8a74aa66d1a	2024-07-02	2	0
\.


--
-- TOC entry 4940 (class 0 OID 18060)
-- Dependencies: 226
-- Data for Name: review; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.review (id_review, grade, comment_r, "OfferId") FROM stdin;
\.


--
-- TOC entry 4941 (class 0 OID 18070)
-- Dependencies: 227
-- Data for Name: vote; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.vote (person_id_voter, request_id_voted, voted_for) FROM stdin;
\.


--
-- TOC entry 4708 (class 2606 OID 17962)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4723 (class 2606 OID 17997)
-- Name: account PK_account; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.account
    ADD CONSTRAINT "PK_account" PRIMARY KEY (id_acc);


--
-- TOC entry 4710 (class 2606 OID 17967)
-- Name: address PK_address; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT "PK_address" PRIMARY KEY (id_adr);


--
-- TOC entry 4718 (class 2606 OID 17987)
-- Name: animal PK_animal; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.animal
    ADD CONSTRAINT "PK_animal" PRIMARY KEY (id_animal);


--
-- TOC entry 4712 (class 2606 OID 17972)
-- Name: animal_type PK_animal_type; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.animal_type
    ADD CONSTRAINT "PK_animal_type" PRIMARY KEY (id_animal_type);


--
-- TOC entry 4761 (class 2606 OID 18183)
-- Name: association PK_association; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.association
    ADD CONSTRAINT "PK_association" PRIMARY KEY (id_assoc);


--
-- TOC entry 4726 (class 2606 OID 18007)
-- Name: comment PK_comment; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "PK_comment" PRIMARY KEY (id_comment);


--
-- TOC entry 4759 (class 2606 OID 18171)
-- Name: notification PK_notification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notification
    ADD CONSTRAINT "PK_notification" PRIMARY KEY (id_notification);


--
-- TOC entry 4729 (class 2606 OID 18017)
-- Name: offer PK_offer; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT "PK_offer" PRIMARY KEY (id_offer);


--
-- TOC entry 4715 (class 2606 OID 17977)
-- Name: person PK_person; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person
    ADD CONSTRAINT "PK_person" PRIMARY KEY (id_person);


--
-- TOC entry 4735 (class 2606 OID 18039)
-- Name: photo PK_photo; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.photo
    ADD CONSTRAINT "PK_photo" PRIMARY KEY (id_photo);


--
-- TOC entry 4739 (class 2606 OID 18049)
-- Name: post PK_post; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT "PK_post" PRIMARY KEY (id_post);


--
-- TOC entry 4748 (class 2606 OID 18089)
-- Name: post_comments PK_post_comments; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_comments
    ADD CONSTRAINT "PK_post_comments" PRIMARY KEY (comment_id_comment, post_id_post_cmt);


--
-- TOC entry 4751 (class 2606 OID 18104)
-- Name: post_likes PK_post_likes; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_likes
    ADD CONSTRAINT "PK_post_likes" PRIMARY KEY (person_id_liked, post_id_liked);


--
-- TOC entry 4754 (class 2606 OID 18119)
-- Name: post_offers PK_post_offers; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_offers
    ADD CONSTRAINT "PK_post_offers" PRIMARY KEY (offer_id_offer, post_id_post);


--
-- TOC entry 4756 (class 2606 OID 18134)
-- Name: post_state PK_post_state; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_state
    ADD CONSTRAINT "PK_post_state" PRIMARY KEY ("Id");


--
-- TOC entry 4732 (class 2606 OID 18027)
-- Name: request PK_request; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT "PK_request" PRIMARY KEY (id_req);


--
-- TOC entry 4742 (class 2606 OID 18064)
-- Name: review PK_review; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT "PK_review" PRIMARY KEY (id_review);


--
-- TOC entry 4745 (class 2606 OID 18074)
-- Name: vote PK_vote; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vote
    ADD CONSTRAINT "PK_vote" PRIMARY KEY (person_id_voter, request_id_voted);


--
-- TOC entry 4719 (class 1259 OID 18140)
-- Name: IX_account_email; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_account_email" ON public.account USING btree (email);


--
-- TOC entry 4720 (class 1259 OID 18177)
-- Name: IX_account_person_id_person; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_account_person_id_person" ON public.account USING btree (person_id_person);


--
-- TOC entry 4721 (class 1259 OID 18142)
-- Name: IX_account_username; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX "IX_account_username" ON public.account USING btree (username);


--
-- TOC entry 4716 (class 1259 OID 18143)
-- Name: IX_animal_animal_type_id_type; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_animal_animal_type_id_type" ON public.animal USING btree (animal_type_id_type);


--
-- TOC entry 4724 (class 1259 OID 18144)
-- Name: IX_comment_person_author_c; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_comment_person_author_c" ON public.comment USING btree (person_author_c);


--
-- TOC entry 4757 (class 1259 OID 18178)
-- Name: IX_notification_id_recipient; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_notification_id_recipient" ON public.notification USING btree (id_recipient);


--
-- TOC entry 4727 (class 1259 OID 18145)
-- Name: IX_offer_person_author_o; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_offer_person_author_o" ON public.offer USING btree (person_author_o);


--
-- TOC entry 4713 (class 1259 OID 18146)
-- Name: IX_person_address_id_adr; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_person_address_id_adr" ON public.person USING btree (address_id_adr);


--
-- TOC entry 4733 (class 1259 OID 18147)
-- Name: IX_photo_AnimalId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_photo_AnimalId" ON public.photo USING btree ("AnimalId");


--
-- TOC entry 4736 (class 1259 OID 18148)
-- Name: IX_post_animal_animal_id; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_post_animal_animal_id" ON public.post USING btree (animal_animal_id);


--
-- TOC entry 4746 (class 1259 OID 18150)
-- Name: IX_post_comments_post_id_post_cmt; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_post_comments_post_id_post_cmt" ON public.post_comments USING btree (post_id_post_cmt);


--
-- TOC entry 4749 (class 1259 OID 18151)
-- Name: IX_post_likes_post_id_liked; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_post_likes_post_id_liked" ON public.post_likes USING btree (post_id_liked);


--
-- TOC entry 4752 (class 1259 OID 18152)
-- Name: IX_post_offers_post_id_post; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_post_offers_post_id_post" ON public.post_offers USING btree (post_id_post);


--
-- TOC entry 4737 (class 1259 OID 18149)
-- Name: IX_post_person_author_p; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_post_person_author_p" ON public.post USING btree (person_author_p);


--
-- TOC entry 4730 (class 1259 OID 18153)
-- Name: IX_request_person_req_author; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_request_person_req_author" ON public.request USING btree (person_req_author);


--
-- TOC entry 4740 (class 1259 OID 18154)
-- Name: IX_review_OfferId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_review_OfferId" ON public.review USING btree ("OfferId");


--
-- TOC entry 4743 (class 1259 OID 18155)
-- Name: IX_vote_request_id_voted; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_vote_request_id_voted" ON public.vote USING btree (request_id_voted);


--
-- TOC entry 4782 (class 2620 OID 18164)
-- Name: request trg_check_valid_requester; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_check_valid_requester BEFORE INSERT OR UPDATE ON public.request FOR EACH ROW EXECUTE FUNCTION public.fn_validate_request();


--
-- TOC entry 4783 (class 2620 OID 18165)
-- Name: request trg_validate_request; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_validate_request BEFORE INSERT OR UPDATE ON public.request FOR EACH ROW EXECUTE FUNCTION public.fn_validate_request();


--
-- TOC entry 4784 (class 2620 OID 18163)
-- Name: request trigger_check_request; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_check_request BEFORE INSERT OR UPDATE ON public.request FOR EACH ROW EXECUTE FUNCTION public.fn_validate_request();


--
-- TOC entry 4785 (class 2620 OID 18158)
-- Name: post_state trigger_check_statetype; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trigger_check_statetype BEFORE INSERT OR UPDATE ON public.post_state FOR EACH ROW EXECUTE FUNCTION public.fn_check_statetype();


--
-- TOC entry 4764 (class 2606 OID 17998)
-- Name: account FK_account_person_person_id_person; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.account
    ADD CONSTRAINT "FK_account_person_person_id_person" FOREIGN KEY (person_id_person) REFERENCES public.person(id_person);


--
-- TOC entry 4763 (class 2606 OID 17988)
-- Name: animal FK_animal_animal_type_animal_type_id_type; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.animal
    ADD CONSTRAINT "FK_animal_animal_type_animal_type_id_type" FOREIGN KEY (animal_type_id_type) REFERENCES public.animal_type(id_animal_type) ON DELETE CASCADE;


--
-- TOC entry 4765 (class 2606 OID 18008)
-- Name: comment FK_comment_person_person_author_c; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT "FK_comment_person_person_author_c" FOREIGN KEY (person_author_c) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4781 (class 2606 OID 18172)
-- Name: notification FK_notification_person_id_recipient; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notification
    ADD CONSTRAINT "FK_notification_person_id_recipient" FOREIGN KEY (id_recipient) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4766 (class 2606 OID 18018)
-- Name: offer FK_offer_person_person_author_o; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.offer
    ADD CONSTRAINT "FK_offer_person_person_author_o" FOREIGN KEY (person_author_o) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4762 (class 2606 OID 17978)
-- Name: person FK_person_address_address_id_adr; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.person
    ADD CONSTRAINT "FK_person_address_address_id_adr" FOREIGN KEY (address_id_adr) REFERENCES public.address(id_adr) ON DELETE CASCADE;


--
-- TOC entry 4768 (class 2606 OID 18040)
-- Name: photo FK_photo_animal_AnimalId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.photo
    ADD CONSTRAINT "FK_photo_animal_AnimalId" FOREIGN KEY ("AnimalId") REFERENCES public.animal(id_animal);


--
-- TOC entry 4769 (class 2606 OID 18050)
-- Name: post FK_post_animal_animal_animal_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT "FK_post_animal_animal_animal_id" FOREIGN KEY (animal_animal_id) REFERENCES public.animal(id_animal) ON DELETE CASCADE;


--
-- TOC entry 4774 (class 2606 OID 18090)
-- Name: post_comments FK_post_comments_comment_comment_id_comment; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_comments
    ADD CONSTRAINT "FK_post_comments_comment_comment_id_comment" FOREIGN KEY (comment_id_comment) REFERENCES public.comment(id_comment) ON DELETE CASCADE;


--
-- TOC entry 4775 (class 2606 OID 18095)
-- Name: post_comments FK_post_comments_post_post_id_post_cmt; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_comments
    ADD CONSTRAINT "FK_post_comments_post_post_id_post_cmt" FOREIGN KEY (post_id_post_cmt) REFERENCES public.post(id_post) ON DELETE CASCADE;


--
-- TOC entry 4776 (class 2606 OID 18105)
-- Name: post_likes FK_post_likes_person_person_id_liked; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_likes
    ADD CONSTRAINT "FK_post_likes_person_person_id_liked" FOREIGN KEY (person_id_liked) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4777 (class 2606 OID 18110)
-- Name: post_likes FK_post_likes_post_post_id_liked; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_likes
    ADD CONSTRAINT "FK_post_likes_post_post_id_liked" FOREIGN KEY (post_id_liked) REFERENCES public.post(id_post) ON DELETE CASCADE;


--
-- TOC entry 4778 (class 2606 OID 18120)
-- Name: post_offers FK_post_offers_offer_offer_id_offer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_offers
    ADD CONSTRAINT "FK_post_offers_offer_offer_id_offer" FOREIGN KEY (offer_id_offer) REFERENCES public.offer(id_offer) ON DELETE CASCADE;


--
-- TOC entry 4779 (class 2606 OID 18125)
-- Name: post_offers FK_post_offers_post_post_id_post; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_offers
    ADD CONSTRAINT "FK_post_offers_post_post_id_post" FOREIGN KEY (post_id_post) REFERENCES public.post(id_post) ON DELETE CASCADE;


--
-- TOC entry 4770 (class 2606 OID 18055)
-- Name: post FK_post_person_person_author_p; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post
    ADD CONSTRAINT "FK_post_person_person_author_p" FOREIGN KEY (person_author_p) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4780 (class 2606 OID 18135)
-- Name: post_state FK_post_state_post_Id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.post_state
    ADD CONSTRAINT "FK_post_state_post_Id" FOREIGN KEY ("Id") REFERENCES public.post(id_post) ON DELETE CASCADE;


--
-- TOC entry 4767 (class 2606 OID 18028)
-- Name: request FK_request_person_person_req_author; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.request
    ADD CONSTRAINT "FK_request_person_person_req_author" FOREIGN KEY (person_req_author) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4771 (class 2606 OID 18065)
-- Name: review FK_review_offer_OfferId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.review
    ADD CONSTRAINT "FK_review_offer_OfferId" FOREIGN KEY ("OfferId") REFERENCES public.offer(id_offer);


--
-- TOC entry 4772 (class 2606 OID 18075)
-- Name: vote FK_vote_person_person_id_voter; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vote
    ADD CONSTRAINT "FK_vote_person_person_id_voter" FOREIGN KEY (person_id_voter) REFERENCES public.person(id_person) ON DELETE CASCADE;


--
-- TOC entry 4773 (class 2606 OID 18080)
-- Name: vote FK_vote_request_request_id_voted; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.vote
    ADD CONSTRAINT "FK_vote_request_request_id_voted" FOREIGN KEY (request_id_voted) REFERENCES public.request(id_req) ON DELETE CASCADE;


-- Completed on 2024-07-05 11:41:52

--
-- PostgreSQL database dump complete
--

