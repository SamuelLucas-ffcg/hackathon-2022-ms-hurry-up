from sumy.parsers.plaintext import PlaintextParser
from sumy.nlp.tokenizers import Tokenizer
from sumy.summarizers.luhn import LuhnSummarizer

import nltk
nltk.download('punkt')

def queen_text():

    return '''
    Leading the mourning, the new Prime Minister Liz Truss said the Queen had been "the rock on which modern Britain was built".
    
    "Britain is the great country it is today because of her," she added.
    
    Ms Truss met the Queen earlier this week in Scotland when she was appointed prime minister.
    
    Speaking from Downing Street, she said the Queen had been "determined" to continue carrying out her duties.
    
    She said the nation should now come together to help the new monarch King Charles III "bear the awesome responsibility that he now carries for us all".
    
    "God save the King," she concluded.
    
    Ms Truss was informed of the Queen's death at 16:30 BST by senior civil servant Simon Case while she was working in Downing Street, her official spokesman has said
    
    She spoke to the King shortly after making her statement.
    
    Labour leader Sir Keir Starmer said the country would "always treasure Queen Elizabeth II's life of service and devotion to our nation and the Commonwealth".
    
    "Above the clashes of politics, she stood not for what the nation fought over, but what it agreed upon.
    
    "So as our great Elizabethan era comes to an end, we will honour the late Queen's memory by keeping alive the values of public service she embodied."
    
    House of Commons Speaker Sir Lindsay Hoyle said the Queen had "exercised a calm and steadying influence over our country".
    
    He added that she had given people's lives a "sense of equilibrium" during her 70 years on the throne and maintained "unwavering devotion to the UK".
    
    He also said she had provided "advice and the benefit of long experience to 15 prime ministers during her reign".
    
    Parliament is expected to meet on Friday from midday and Saturday from 14:00 to pay tribute to the Queen.
    
    All six living former prime ministers have also sent their condolences and shared memories of the Queen.
    
    Ms Truss's predecessor Boris Johnson tweeted that the Queen would be remembered for her "deep wisdom, and historic understanding, and her seemingly inexhaustible but understated sense of duty".
    
    "Relentless though her diary must have felt, she never once let it show, and to tens of thousands of events - great and small - she brought her smile and her warmth and her gentle humour - and for an unrivalled 70 years she spread that magic around her kingdom.
    
    "She seemed so timeless and so wonderful that I am afraid we had come to believe, like children, that she would just go on and on."
    
    Theresa May tweeted: "On the 75th anniversary of VE Day, Her Majesty reminded us to 'never give up, never despair'.
    
    "It was an address that captured not just the national spirit, but Queen Elizabeth's spirit - a sense of quiet determination, of courage, of faith and of hope in the future."
    
    During her 70-year reign, Queen Elizabeth held weekly meetings with the prime minister of the day.
    
    Recalling these conversations during an interview with the BBC, Mrs May said the Queen was "immensely knowledgeable" adding: "Many people don't realise how much work the Queen put into her red boxes, to understand the issues of the day, what was going on in government and around the rest of the world."
    
    Sir John Major - who served as prime minister between 1990 and 1997 - echoed Mrs May's thoughts describing the Queen as "exceptionally well briefed".
    
    "On foreign affairs, she would often say if there was a difficulty of a foreign leader 'Well, I met him many years ago' or even 'I knew his father'."
    
    Sir John said the meetings were not always serious and often filled with "a great deal of gossip... those meetings with the Queen were always the better part of a prime minister's week".
    
    David Cameron described the Queen as "the world's most experienced diplomat" and said he was "fortunate" to have been able to call on her knowledge during his time in office.
    
    Gordon Brown said the Queen was a "compassionate, dedicated, wonderful public servant and nobody will ever forget the contribution she made to our country.
    
    "She was a peacemaker, she brought people together, she listened to people."
    
    Sir Tony Blair - who was prime minister between 1997 and 2007 - said: "We have lost not just our monarch but the matriarch of our nation, the figure who more than any other brought our country together, kept us in touch with our better nature, personified everything which makes us proud to be British."
    
    He recalled his last meeting with the Queen when he said she had been on "sparkling form".
    
    Liberal Democrat leader Sir Ed Davey said the Queen represented "duty and courage, as well as "warmth and compassion".
    
    Scotland's First Minister Nicola Sturgeon praised the Queen's life as "one of extraordinary dedication and service".
    
    The Queen died at her Balmoral estate in Scotland and Ms Sturgeon said she hoped it would be "a source of comfort to her family that she spent her final days in a place that she loved so much".
    
    Wales' First Minister Mark Drakeford said the Queen had "firmly upheld the values and traditions of the British Monarchy" and offered his "deepest condolences".
    '''

def summarize(doc):

    # For Strings
    parser=PlaintextParser.from_string(doc,Tokenizer("english"))
    # Using KL
    summarizer = LuhnSummarizer()
    #Summarize the document with 4 sentences
    summary = summarizer(parser.document,4)
    
    text = ""
    
    for sentence in summary:
        text += str(sentence)

    return text






