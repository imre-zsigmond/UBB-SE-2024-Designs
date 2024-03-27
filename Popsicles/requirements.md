**GROUP:**
- Users can create groups, with a group having only one owner.
- Each group accommodates users through a feed, where users can post and interact.
- Groups support assigning roles to members: admin, moderator, user, and custom roles for decoration.
- The admin role is held only by the group owner, who can manage users, posts, and group settings.
- Groups have a general feed with filtering options based on tags for customized viewing.
- Group settings include max posts per hour for an user, group icon, group banner, name, description, password, ability to make posts by default and visibility (private or public).

**GROUP MEMBER:**
- Members have three functional roles: admin, moderator, or user.
  - User:
    - Can create posts if enabled.
    - Can invite others if the group is public.
  - Admin:
    - All user powers.
    - Automatically assigned to the group owner.
    - Can modify roles, create new decorative ones.
    - Can remove, invite (regardless of group visibility), and ban users.
    - Can delete, hide, or pin posts.
    - Can ban, unban, timeout, or untimeout users.
    - Can assign right to create posts to users (if off by default).
    - Can modify group settings.
    - Create, approve, or reject invites.
  - Moderator:
    - All powers of an admin except:
      - deleting posts
      - banning users
      - demoting other moderators, admins
      - creating other moderators, admins
- Members can create posts within the group if given the right.
- Members can filter the group feed based on tags (user defined ones or automatic ones based on content), allowing customized viewing.

**GROUP FEED:**
- Feeds can be filtered based on tags (user-defined or automatic) for customized viewing.
- Feeds contain multiple posts.
- Posts can be pinned to the top of the feed by admins.

**GROUP POST:**
- Posts have user-defined or automatic tags based on content.
  - Ex: A post containing a video will have a `video` tag.
- Admins can pin posts to the top of the feed.

**POLL:**
- Polls are single or multiple-choice.
- Polls can have a time limit within which are active.
- The platform allows creating paid polls and restricting result visibility.
- It supports live and non-live polling formats for real-time or pre-scheduled interactions.
