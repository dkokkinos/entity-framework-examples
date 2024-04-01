<h1 align="center">
  <br>
  <a href="https://softwareparticles.com/many-to-many-relationship-with-net5-and-entityframework/"><img src="https://softwareparticles.com/wp-content/uploads/2024/02/T1.png" alt="Markdownify" width="500"></a>
  <br>
  Configuring Many To Many Relationship in .NET and Entity Framework
  <br>
</h1>

<p>Checkout the related article to learn more -> https://softwareparticles.com/many-to-many-relationship-with-net5-and-entityframework/</p>

<h3>EntityFramework.ManyToManyWithJoinTable</h3>
<p>Model the join table as a separate entity in the code. Both ends of the relationship have a reference to the join table.</p>

<h3>EntityFramework.ManyToManyWithoutJoinTable</h3>
<p>We don’t have the join table as a separate entity in our code. We utilize collections navigation properties between (User and Book) entities. Let Entity Framework handle the creation of the join table in the database.</p>

<h3>EntityFramework.ManyToManyWithConfigurableJoinTable</h3>
<p>If we require the join table to be a separate entity in our code, yet still want to utilize collections between User and Book entities without referencing the join table directly, then we can use a join table and add a specific configuration.</p>

