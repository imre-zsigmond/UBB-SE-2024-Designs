# ISS_Buying_Selling
We are creating the buying and selling part for groups for a social media platform



Our tasks :

take each big task and make it into 4 roughly equal parts 

Don t forget - feasible, valid, unambiguous, verifiable, consistent 

If we don t give him reasons, he will give us all the money. 

If something is dependent on other groups tasks, assume it has a callable function that gets the info.

----WE GOT BUYING/SELLING----


They are features for already coded(by someone else) groups.



Make a marketplace inside a group

A group admin can give a user the ability to sell something
A user can request to make a selling post
Admins have the ability to remove a post
Users can report a post
- add reviews for selling


Target complexity ~ 1 database/table per team member 

Entities:
- groups
- users
- SellingUserScore
- Cart
- Favorites
- FixedPricePost
- Auction
- DonationPost
- Post
- InterestStatus
- Comment
- Report




All selling Posts:
- any user who isn't banned can make a request to the administrators to sell a product at a fixed price
- any admin can validate or reject a request from a user to sell a product
- any user can report the post
- when a selling post has received more than 50% of reports from people that have seen the post(more than 10 people), the post will be sent to an admin to validate
- any user has a rating for buying and a different rating for selling
- any user with a selling rating over 75% does not need to make a request to the administrators to sell something
- any user without a selling rating or a selling rating below 75% will need to make a request to an administrator to sell a product
- any users who makes a selling post can choose a minimum buying rating for the users that can buy the product
- when a transaction ends the buyer and the seller choose a rating for each other, this is done through an automated message, at about 3 days after a transaction

Fixed price:
- selling with a fixed price decided the by the seller
- a fixed price post will be deleted if nobody buys it in 3 months
- a buy needs to first be confirmed by the seller, it can choose if the transaction goes forward or not
- a buy needs to be confirmed after by the buyer
- the confirmation is done through an automated message, that looks like a normal message, that the users receive

Auctions:
- a user can create an auction by either making a request to the moderators or having a rating over 75%
- the user who creates the auction can set a minimum bidding price
- the auctioneer can set the starting price
- the auctioneer can decide when to end the auction, either by ending it manually or choosing a price at which the auction will end
- the auctioneer can also end the auction by agreeing with a buyer for a certain price
- any auction must last at minimum 1 day, unless ended by the auctioneer by agreeing with a buyer, and at maximum 30 days, unless the auction goes overtime due to bids being made at the last minutes
- if the auction has less than 30 seconds left, any bid made will reset the time until it expires to 30 seconds

Donation:
- a user can create a donation post for any cause
- the donation post must have a button which, when pressed, will open the website of the charity	
- any user can make a request to the moderators to be able to request donations
- any user can donate
- users with a rating over 75% do not need to make requests to the moderators to request donations
	

Interest and Uninterest:
- a user that wants to buy the product can choose to be interested or uninterested in a product
- more interest means a post is higher up in the feed
- less interest pushes it down
- sorted in descending order using (nrOfInterests - nrOfUninterests) for each post

Promote:
- a user can decide to promote his post
- a promoted post shows up first in the feed, if there are more promoted posts they will be ordered using the interested and uninterested criteria
- a promoted post will lose its promotion status after 15 days

Discounts:
- a user which has bought 10 times can receive a discount of 10% on his next buy, 10 more buys and he gets the discount again
- a user that has sold at least 10 times becomes a big seller for his next selling post
- being a big seller on a post means you get free promotion for that post for a week

Cart:
- a user can choose items to put in his cart
- only fixed price posts can be put in the cart
- a seller knows if his item has been added to the cart and how many times, he does NOT know who has them
- a user can press a button to buy every item in his cart

Favorites:
- any selling post can be favorited
- a user can choose to favorite a post
- a user can see all his favorited items
- a selling user can see how many people have favorited his post
- a user can sort the items in the marketplace by how many favorites the posts have





	
